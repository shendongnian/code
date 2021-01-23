        ConstructorInfo GetBestConstructor(XElement elm, Type itemType)
        {
            var elements = elm.Elements();
            // Get a constructor with the most parameters that
            // are provided by xml elements.
            var ctor = (
                from c in itemType.GetConstructors()
                let p = c.GetParameters()
                where
                    p.Length > 0 &&
                    p.Count(parm => elements.Any(e => e.Name.LocalName.Equals(parm.Name, StringComparison.InvariantCultureIgnoreCase))) == p.Length
                select c
            )
                // Put the constructor with the most matching parameters
                // at the top of the list
            .OrderByDescending(c => c.GetParameters().Length)
            .FirstOrDefault();
            return ctor;
        }
        TType Construct<TType>(XElement elm)
        {
            var ctor = GetBestConstructor(elm, typeof(TType));
            if (ctor != null)
            {
                // We found a valid contructor!
                List<object> parameters = new List<object>();
                // Build a list of parameters, deserializing as we go.
                foreach (var p in ctor.GetParameters())
                {
                    var item = elm.Elements().FirstOrDefault(e => e.Name.LocalName.Equals(p.Name, StringComparison.InvariantCultureIgnoreCase));
                    if (item != null)
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(p.ParameterType);
                        if (converter != null &&
                            converter.CanConvertFrom(typeof(string)))
                        {
                            // Deserialize each parameter and add it.
                            var parameter = converter.ConvertFrom(item.Value);
                            parameters.Add(parameter);
                        }
                    }
                }
                // Create the object, using each parameter we've deserialized
                // to pass to the constructor.
                return (TType)ctor.Invoke(parameters.ToArray());
            }
            return default(TType);
        }
        public class User
        {
            public User(string name, string gender, string imageUrl)
            {
                Name = name;
                Gender = gender;
                ImageUrl = imageUrl;
            }
            public string Name { get; protected set; }
            public string Gender { get; protected set; }
            public string ImageUrl { get; protected set; }
        }
        public IEnumerable<User> GetUsers()
        {
            XDocument doc = XDocument.Parse(@"
    <User>
        <Name>X</Name>
        <Gender>Y</Gender>
        <ImageUrl>Z</ImageUrl>
    </User>");
            
            return doc
                .Descendants("User")
                .Select(u => Construct<User>(u));
        }
        static public void Main()
        {
            var p = new Program();
            var users = p.GetUsers().ToArray();
        }

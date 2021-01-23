        [Test]
        public void dummy()
        {
            var conditions = new Conditions();
            var propertyInfos = conditions.GetType().GetProperties();
            propertyInfos.ForEach(x =>
                {
                    var attrs = x.GetCustomAttributes(true);
                    if (attrs.Any(p => p.GetType() == typeof(XmlTextAttribute)))
                    {
                        Console.WriteLine("{0} {1}", x, attrs.Aggregate((o, o1) => string.Format("{0},{1}",o,o1)));
                    }
                });
        }

    class PropertySetTest
    {
        static readonly Type resType = typeof(Car);
        internal static T ParseObjectGraph<T>(Dictionary<string, object> oGraph)
        {
            Object generic = Activator.CreateInstance<T>();
            foreach (var pi in resType.GetProperties())
            {
                //No need to new() this
                object outObj; // = new object();
                if (oGraph.TryGetValue(pi.Name.ToLower(), out outObj))
                {
                    var outType = outObj.GetType();
                    if (outType == pi.PropertyType)
                        pi.SetValue(generic, outObj, null);
                }
            }
            return (T)generic;
        }
        [Test]
        public void Test()
        {
            var typeData = new Dictionary<String, Object> {{"color", "Blue"}};
            var myCar = ParseObjectGraph<Car>(typeData);
            Assert.AreEqual("Blue", myCar.Color);
        }
    }
    internal struct Car
    {
        public String Color { get; set; }
    }

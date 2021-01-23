        public class SomeAttribute : Attribute
        {
            public SomeAttribute(string value)
            {
                this.Value = value;
            }
            public string Value { get; set; }
        }
        public class SomeClass
        {
            public string Value = "Test";
        }
        [TestMethod]
        public void CanAddAttribute()
        {
            var type = typeof(SomeClass);
            var aName = new System.Reflection.AssemblyName("SomeNamespace");
            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            var mb = ab.DefineDynamicModule(aName.Name);
            var tb = mb.DefineType(type.Name + "Proxy",System.Reflection.TypeAttributes.Public, type);
            var attrCtorParams = new Type[] { typeof(string) };
            var attrCtorInfo = typeof(SomeAttribute).GetConstructor(attrCtorParams);
            var attrBuilder = new CustomAttributeBuilder(attrCtorInfo, new object[] { "Some Value" });
            tb.SetCustomAttribute(attrBuilder);
            var newType = tb.CreateType();
            var instance = (SomeClass)Activator.CreateInstance(newType);
            Assert.AreEqual("Test", instance.Value);
            var attr = (SomeAttribute)instance.GetType().GetCustomAttributes(typeof(SomeAttribute), false).SingleOrDefault();
            Assert.IsNotNull(attr);
            Assert.AreEqual(attr.Value, "Some Value");
        }

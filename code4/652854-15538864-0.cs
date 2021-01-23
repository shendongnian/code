        [Test]
        public void dummy()
        {
            var conditions = new Conditions();
            var propertyInfos = conditions.GetType().GetProperties().Where(x => x.GetCustomAttributes(true).Any(p => p.GetType() == typeof(XmlTextAttribute)));
            Console.WriteLine(propertyInfos.Count());
            propertyInfos.ForEach(Console.WriteLine);
        }

        public class Thing
        {
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
        public decimal GetValue(Thing thing)
        {
            return thing.Value;
        }
        public Thing[] Things =
            {
                new Thing { Name="Stapler", Value=20.35M},
                new Thing { Name="Eraser", Value=0.65M}
            };
            
        [TestMethod]
        public void GetValueListFromThing()
        {
            // query notation, direct projection
            List<decimal> valuesA 
                = (from t in Things
                   select t.Value).ToList();
            // query notation, projection with method
            List<decimal> valuesB 
                = (from t in Things
                   select GetValue(t)).ToList();
            // functional notation, projection with method
            List<decimal> valuesC 
                = Things.Select(t => GetValue(t)).ToList();
            // functional notation, projection with anonymous delegate
            List<decimal> valuesD 
                = Things.Select(t => { return t.Value; }).ToList();
            // functional notation, lambda expression
            List<decimal> values
                = Things.Select(t => t.Value).ToList();
        }

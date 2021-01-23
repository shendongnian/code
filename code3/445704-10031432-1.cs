        public class Model
        {
            public int ID { get; set; }
            public DateTime BeginDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Name { get; set; }
    
            public static List<Model> GetModels()
            {
                return new List<Model> {
                    new Model{ BeginDate=DateTime.Now,
                               EndDate=DateTime.Now.AddDays(1), ID=1, Name="test"},
                    new Model{ BeginDate=DateTime.Now.AddDays(10),
                               EndDate=DateTime.Now.AddDays(12), ID=1, Name="test 2"}
                };
            }
        }

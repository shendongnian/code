    class Program
        {
            static void Main(string[] args)
            {
                agencia ag1 = new agencia()
                {
                    name = "Iquique",
                    data = new object[] { new object[] {"Lucas", 20 }, new object[] {"Fernando", 15 } }
                };
                agencia ag2 = new agencia()
                {
                    name = "Valparaiso",
                    data = new object[] { new object[] { "Rems", 20 }, new object[] { "Perex", 15 } }
                };
                agencia agn = new agencia()
                {
                    name = "Santiago",
                    data = new object[] { new object[] { "Jhon", 20 }, new object[] { "Karma", 15 } }
                };
    
    
                Dictionary<string, agencia> dic = new Dictionary<string, agencia>
                {
                    { "Iquique", ag1 },
                    { "Valparaiso", ag2 },
                    { "Santiago", agn }
                };
    
                string da = Newtonsoft.Json.JsonConvert.SerializeObject(dic);
    
                Console.WriteLine(da);
                Console.ReadLine();
            }
    
            
        }
    
        public class agencia
        {
            public string name { get; set; }
            public object[] data { get; set; }
        }

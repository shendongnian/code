    public class Scripts
    {
        public static string Sql1
        {
            get
            {
                return GetResource("sql1.sql");
            }
        }
        
       public static string Sql2
       {
            get
            {
               return GetResource("sql2.sql");
            }
       }
        private static string GetResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using(var stream = new StreamReader(assembly.GetManifestResourceStream("Myproject.Sql." + name)))
            {
                return stream.ReadToEnd();
            }
        }
    }

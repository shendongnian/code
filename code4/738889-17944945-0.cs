    using System.Text;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            var d = new
            {
                longUrl = "http://api.themoviedb.org/3/person/12835?api_key=2c50a994de5291887a4e062edd229a72",
                someOtherProeprty = 1
            };
            var s = new JsonSerializer();
            var sb = new StringBuilder();
            using (var w = new StringWriter(sb))
            {
                s.Serialize(w, d);
            }
            Console.WriteLine(sb.ToString());
        }
    }

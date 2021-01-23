    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Services;
    
    namespace DemoTagit
    {
        public class Info
        {
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public String Email { get; set; }
        }
    
        public partial class _default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            [WebMethod]
            public static List<Info> GetKeyword(string match)
            {
                var qry = GetInfo().Distinct().Where(k => k.Name.ToLower().StartsWith(match.ToLower()));
                return qry.ToList();
            }
    
            public static IEnumerable<Info> GetInfo()
            {
                List<Info> list = new List<Info>();
                list.Add(new Info { Id = 1, Name = "Tom", Email = "Tom@Email.com" });
                list.Add(new Info { Id = 2, Name = "Torex", Email = "Torex@Email.com" });
                list.Add(new Info { Id = 3, Name = "Tresa", Email = "Tresa@Email.com" });
                list.Add(new Info { Id = 4, Name = "Morgan", Email = "Morgan@Email.com" });
                list.Add(new Info { Id = 5, Name = "Paris", Email = "Paris@Email.com" });
                list.Add(new Info { Id = 6, Name = "Patrick", Email = "Patrick@Email.com" });
                return list;
            }
    
        }
    }

    public class POCO
    {
         public string id { get; set; }
         public string name { get; set; }
    }
    
    var query2 = from s in Tables[Table_Sec].AsEnumerable()
                 where query.Contains(s["sectype"])
                 select new POCO { id = s["id"], name = s["name"] };

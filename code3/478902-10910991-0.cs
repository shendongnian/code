        public class RaumklassenHelper
    {
       
            public class RAUMKLASSE
            {
                public string Name { get; set; }
                public string Name_En { get; set; }
            }
            
            
            internal static List<RAUMKLASSE> Raumklasse()
       {
           List<RAUMKLASSE> raumKlassenObject = new List<RAUMKLASSE>();
    
           using (SqlConnection con = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=BOOK-IT-V2;Integrated Security=true;"))
           using (SqlCommand cmd = new SqlCommand(@"SELECT BEZEICHNUNG, BEZEICHNUNG_EN FROM RAUMKLASSE", con))
           {
               con.Open();
               using (SqlDataReader rdr = cmd.ExecuteReader())
               {
                   while (rdr.Read())
                   {
                       if (rdr["BEZEICHNUNG"] != DBNull.Value && rdr["BEZEICHNUNG_EN"] != DBNull.Value)
                       {
                           raumKlassenObject.Add(new RAUMKLASSE()
                               {
                                   Name = rdr["BEZEICHNUNG"].ToString(),
                                   Name_En = rdr["BEZEICHNUNG_EN"].ToString()
                               });
                       }
                   }
               }
           }
           return raumKlassenObject;
       }
    }
    
    
    
     [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
       [WebMethod]
       public List<RAUMKLASSE> Raumklasse()
       {
           return RaumklassenHelper.Raumklasse();
       }

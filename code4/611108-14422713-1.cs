    public class YourTypeName
    {
         public string Cfrom {get; set;}
         public string Pfrom {get; set;}
    }
    
    var query = from r in matrix.AsEnumerable()
                    where r.Field<string>("c_to") == c_to &&
                          r.Field<string>("p_to") == p_to
                    select new YourTypeName
                    {
                        Cfrom = r.Field<string>("c_from"), 
                        Pfrom =  r.Field<string>("p_from")
                    };
    
    DataTable conversions = query.CopyToDataTable();

    public class YourTypeName
    {
         public Cfrom {get; set;}
         public Cfrom {get; set;}
    }
    
    var query = from r in matrix.AsEnumerable()
                    where r.Field<string>("c_to") == c_to &&
                          r.Field<string>("p_to") == p_to
                    select new YourTypeName
                    {
                        c_from = r.Field<string>("c_from"), 
                        p_from =  r.Field<string>("p_from")
                    };
    
    DataTable conversions = query.CopyToDataTable();

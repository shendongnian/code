    public static List<string> ReceiveDBlist(string Company)
    {
        List<string> result = new List<string>();
        
        var Cases = from q in db.Cases
                    where q.Company == Company
                    select q;
        
        foreach(var c in Cases)
        {
            string row = c.Column1 + ";" + c.Column2 + ";" + c.Column3;
            result.Add(row);
        }
    
        return result;
    }

    public List<string> FindName(int ChrLength)
    {
           var query = db.Users.Where(u => u.FullName.Length > ChrLength)
                               .Select(u => u.FullName).ToList();
           foreach(var s in query) 
               Console.WriteLine(s);
           return query;
    }

    class Company
    {
        public string Name { get; }
        public DateTime Date { get; }
    }
    
    var companies = new List<Company>();
    
    var query = companies.GroupBy(c => c.Name).Select(g => new { Name = g.Key, MinDate = g.Min(c => c.Date) });

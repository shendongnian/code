    class Company
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    
    var companies = new List<Company>();
    
    var companiesWithMinDate = companies.GroupBy(c => c.Name).Select(g => new { Name = g.Key, Date = g.Min(c => c.Date) });

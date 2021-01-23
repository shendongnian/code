    public List<Customer> ByWeek(int year, int week) {
       return db.Customers.Where(p => 
                       SqlFunctions.DatePart("week", p.Createon) == week && 
                       SqlFunctions.DatePart("year", p.Createon) == year
                       );
    
    }

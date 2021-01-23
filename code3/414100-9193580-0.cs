    class IEmployeeEntity
    {
       public DateTime StartDate {set; get;}
    
       public DateTime FormatedStartDate {  get  { return StartDate.ToString("MM/dd/yyyy") } }
    
    }

    class IEmployeeEntity
    {
       private DateTime startDate;
       public DateTime StartDate 
       { 
           set 
              { 
                  startDate = value; 
              } 
           get { 
                  return startDate.ToString("MM/dd/yyyy"); 
               } 
        }
    }

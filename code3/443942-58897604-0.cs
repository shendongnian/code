    SearchUsingDate(DateTime? StartDate, DateTime? EndDate){
    	 DateTime LastDate;
         if (EndDate != null)
           {
              LastDate = (DateTime)EndDate;
              LastDate = LastDate.AddDays(1);
              EndDate = LastDate;
            }
    }

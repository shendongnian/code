    Func<MySale, DateTime, int> calcDaysMonth = (sale, currDate) => 
    {
         if (matchMonth(sale.ActivationDate, sale.EndDate))
         {
                 return (sale.EndDate.Day - sale.ActivationDate.Day + 1);
         }
         else
         {
            if (matchMonth(sale.ActivationDate, currDate))
               return (currDate.AddMonths(1) - sale.ActivationDate).Days;
            else if (matchMonth(sale.EndDate, currDate)
               return sale.EndDate.Day;
            else 
               return 0;
         }
    }

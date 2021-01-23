            string FinYear=null;
            if (DateTime.Today.Month > 3)
            {
              
                FinYear = "1/4/" + DateTime.Today.Year;
            }
            else
            {
                FinYear = "1/4/" + (DateTime.Today.Year - 1);
            }

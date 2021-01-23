    if (string.IsNullOrEmpty(Request.Form["StartDate"]) == false)
            {
                DateTime strtDate;
                try
                  {
                    strtDate = Convert.ToDateTime(Request.Form["StartDate"]);
                    _startDate = strtDate;
                  }
                catch(Exception)
                  {
                   _startDate = null;
                  }
             }
            else
            { 
           _startDate = null;
            }

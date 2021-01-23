        protected Site1 Site1Master
        {
            get 
            { 
               if (!(Master is Site1))
                  throw new Exception("This page doesn's have Site1 as master page");
               return Master as Site1; 
            }
        }

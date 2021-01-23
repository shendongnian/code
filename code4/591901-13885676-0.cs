        public class CustomerFilters
        {
            public IEnumerable<Expression<Func<Customer, bool>>> Filters()
            {
                if (/*check if should filter on FirstName here*/)
                {
                    yield return cust => cust.FirstName == FirstNameSearchString;
                }
                if (/*check if should filter on Surname here*/)
                {
                    yield return cust => cust.Surname == SurnameSearchString;
                }
            }
        }

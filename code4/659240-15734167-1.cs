    public bool IsValid
            {
                get
                {
                    return (!String.IsNullOrWhiteSpace(StreetName) && !String.IsNullOrWhiteSpace(City) && !String.IsNullOrWhiteSpace(HouseNumber.ToString) && !String.IsNullOrWhiteSpace(ZipCode.ToString) && !String.IsNullOrWhiteSpace(Price.ToString) );
                }
            }

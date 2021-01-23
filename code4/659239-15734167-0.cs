    public bool IsValid
            {
                get
                {
                    return (!String.IsNullOrWhiteSpace(StreetName) && !String.IsNullOrWhiteSpace(City) && HouseNumber != 0 && ZipCode != 0 && Price != 0);
                }
            }

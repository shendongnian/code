    public static List<Country> LoadOrderedCountries(){
         var orderedCounteries = MyMethods.LoadCountries(); 
         orderedCounteries .Sort(); // Just to make sure alphabetical order, assuming that Country implements IComparable
         var defaultCountry = Country.GetDefault();
         orderedCounteries .Remove(defaultCountry);
         orderedCounteries .Insert(0, defaultCountry);
    
         return orderedCounteries ;
    }

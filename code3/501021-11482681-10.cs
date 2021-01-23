    public int[] IterateOverAllCountries () {
        // define what countries you are dealing with
        string[] countries = new string[] { "Pakistan", "India", "USA", "Iran", "UK", }
        // range of numbers forming the postfix of your country strings
        int numbersToLookFor = 4;        
        // provide an array that stores all the local results
        // numbersToLookFor + 1 to respect that numbers are starting with 0
        Result[] result = new int[countries.Length * numbersToLookFor + 1];
    
        string currentCountry;
        // iterate over all countries
        for (int i = 0; i < countries.Length; i++) {
    
            currentCountry = countries[i];
            int j = 0;
            // do that for every number beginning with 0
            // (according to your question)
            int localResult;          
            while (j <= numbersToLookFor) {
                localResult = FindCountryPosition(currentCountry, j);
                // add another result to the array of all results
                result[i+j] = new Result() { Country = currentCountry, Number = j, Result = localResult };
                j++;
            }
        } 
    }

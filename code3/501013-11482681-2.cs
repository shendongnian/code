    public int[] IterateOverAllCountries () {
        // define what countries you are dealing with
        int[] positions = new int[countries.Length];
        // range of numbers forming the postfix of your country strings
        int numbersToLookFor = 4;
    
        string currentCountry;
        // iterate over all countries
        for (int i = 0; i < countries.Length; i++) {
    
            currentCountry = countries[i];
            int j = 0;
            // do that for every number beginning with 0
            // (according to your question)
            while (j <= numbersToLookFor) {
                positions[i] = FindCountryPosition(currentCountry, j);
                j++;
            }
        } 
    }

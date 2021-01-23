    public static Result[] IterateOverAllCountries () {
        // range of numbers forming the postfix of your country strings
        int numbersToLookFor = 4;        
        // provide an array that stores all the local results
        // numbersToLookFor + 1 to respect that numbers are starting with 0
        Result[] result = new Result[countries.Length * (numbersToLookFor + 1)];
        string currentCountry;
        int c = 0;
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
                result[c] = new Result() { Country = currentCountry, Number = j, Occurrences = localResult };
                j++;
                c++;
            }
        }
        return result;
    }

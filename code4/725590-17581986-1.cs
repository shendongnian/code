    public double Average()
    {
        double sum = temp[0]; // sum of temperatures, starting from value of first one in array
        double lowest = temp[0]; // buffer for lowest temperature value
        for (int c = 1; c < 7; c++) // start loop from second position in array
        {
            if (temp[c] < lowest) // checking if next value in array is smaller than the lowest one so far...
            {
                lowest = temp[c]; // ...if so, value of variable lowest is changing
            }
            sum = sum + temp[c]; // adding temparatures value to variable sum, one by one
        }
        sum = sum - lowest; // at the end we substract lowest value from sum of all temperatures
        double average = sum / 6; // average value calculation
        return average;
    }

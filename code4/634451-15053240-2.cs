    public static int[] splitNumberIntoGroupOfDigits(int number)
    {
        var numberOfDigits = Math.Floor(Math.Log10(number) + 1); // compute number of digits
        var intArray = new int[Convert.ToInt32(numberOfDigits / 3)]; // we know the size of array
        var lastIndex = intArray.Length -1; // start filling array from the end
 
        while (number != 0)
        {
            var lastSet = number % 1000;
            number = number / 1000;
            if (lastSet == 0)
            {
                intArray[lastIndex] = 0;  // set of zeros
                --lastIndex;                    
            }
            else if (number == 0)
            {
                intArray[lastIndex] = lastSet; // this could be your last set
                --lastIndex;                    
            }
            else
            {
                intArray[lastIndex] = lastSet;
                --lastIndex;                    
            }
        }
        return intArray;
    }

    using System;
    using System.Collections;
    
    namespace ConsoleApplication
    {
        class Numbers
        {
            public ArrayList RandomNumbers(int max)
            {
                // Create an ArrayList object that will hold the numbers
                ArrayList lstNumbers = new ArrayList();
                // The Random class will be used to generate numbers
                Random rndNumber = new Random();
    
                // Generate a random number between 1 and the Max
                int number = rndNumber.Next(1, max + 1);
                // Add this first random number to the list
                lstNumbers.Add(number);
                // Set a count of numbers to 0 to start
                int count = 0;
    
                do // Repeatedly...
                {
                    // ... generate a random number between 1 and the Max
                    number = rndNumber.Next(1, max + 1);
    
                    // If the newly generated number in not yet in the list...
                    if (!lstNumbers.Contains(number))
                    {
                        // ... add it
                        lstNumbers.Add(number);
                    }
    
                    // Increase the count
                    count++;
                } while (count <= 10 * max); // Do that again
    
                // Once the list is built, return it
                return lstNumbers;
            }
        }

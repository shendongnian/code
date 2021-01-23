            static void Main(string[] args)
            { 
                //input data
                int[] inputArray = new int[5];
                int enteredCount = 0;
                string enteredLine = string.Empty;
    
                Console.WriteLine("Enter numbers from 0 to 10. If you want to end please enter nothing");
                //while user input something not blank
                while ((enteredLine = Console.ReadLine()) != string.Empty)
                {
                    //inputArray has no more elements, resize it
                    if (enteredCount == inputArray.Length)
                    {
                        Array.Resize<int>(ref inputArray, inputArray.Length + 5);
                    }
    
                    //new entered value to array
                    inputArray[enteredCount] = int.Parse(enteredLine);
                    enteredCount++;
                }
    
                //now we need count all uniq elements
                //special array. Index is a number from 0 to 10. Value is a count of that value
                int[] counts = new int[11];
                for (int i = 0; i < enteredCount; i++)
                {
                    int enteredNumber = inputArray[i];
                    counts[enteredNumber]++;
                }
    
                Console.WriteLine("Totally were entered {0} numbers", enteredCount);
    
                //now we now count of each number from 0 to 11. Let' print them
                for (int i = 0; i < 11; i++)
                {
                    //Print only numbers, that we entered at least once
                    if (counts[i] != 0)
                        Console.WriteLine("Number {0} were entered {1} times", i, counts[i]);
                }
    
                Console.ReadLine();
            }

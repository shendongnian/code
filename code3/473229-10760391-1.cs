    private static void Main(string[] args) {
            var running = true;
            var numbers = new List<int>();
            
            //Enter Question Asking Loop w/ running=true
            while (running) {
                Console.Write("Enter a number or enter 999 to exit: ");
                int inputValue;
                var inputString = Console.ReadLine();
                //Check for "999" which indicates we should display the numbers entered, the total and then exit our loop.
                if (inputString == "999") {
                    //Display the numbers entered
                    foreach (var number in numbers) {
                        Console.WriteLine(number);
                    }
                    Console.WriteLine("The sum of the values in your array is: " + numbers.Sum());
                    running = false;
                }
                else if (Int32.TryParse(inputString, out inputValue) && inputValue > 0) {
                    //We have valid input, append it to our collection
                    numbers.Add(inputValue);                    
                }
                else {
                    //The user entered invalid data. Let them know.
                    Console.WriteLine("Please enter a whole number greater than 0");
                }                
            }
            //Loop complete
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

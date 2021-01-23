    static void Main(string[] args)
    {
        const int QUIT = -1;
        int[] last3 = new int[3];
        // infinite loop, exit is done when input is -1
        for(;;) {
            Console.Write("Type a number (type -1 to quit): ");
            var input = Console.ReadLine();
            int tmp; // holds the int value of the input
            if (int.TryParse(input, out tmp))
            {
                if (tmp == QUIT)
                    break; // input is -1
                // input was an int, so lets move the last two towards
                // the front of the array, last3[0] contained the oldest value
                // which is gone now
                last3[0] = last3[1];
                last3[1] = last3[2];
                // now overwrite the last item in the array with the newest value 
                last3[2] = tmp;
            }
            // add up the values, note if input was not a valid int, this will sum
            // the last 3 valid values because the above if statement will only execute
            // and change the values in the array if the user input was a number
            var sum = last3[0] + last3[1] + last3[2];
            Console.WriteLine("Sum of the past three numbers is: {0}", sum);
        }
    }

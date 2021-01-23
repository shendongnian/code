    static void Main(string[] args)
    {
        Random randomObject = new Random();
        int randomDirection;
        while (true) { //because your program needs to run infinitely
            Console.WriteLine("Enter the number of steps:");
            n = int.Parse(Console.ReadLine());
            //You walk a random way each step
            for (int i = 0; i < n; i++)
            {
                randomDirection = randomObject.Next(1,5);
                if (randomDirection == 1)
                {
                    //walk right
                }
                if (randomDirection == 2)
                {
                    //walk left
                }
                if (randomDirection == 3)
                {
                    //walk up
                }
                if (randomDirection == 4)
                {
                    //walk down
                }
                //Also check if you aren't walking against walls! 
            }
         }
    }

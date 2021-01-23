        int intUserNum = int.Parse(Console.ReadLine());
        do
        {
            if (intUserNum == intRandomNum)
            {
                Console.WriteLine("You got it! Great job!");
            }
            if (intUserNum < intRandomNum)
            {
                Console.WriteLine("Too low! Try Again.");
                intUserNum = int.Parse(Console.ReadLine());
            }
            if (intUserNum > intRandomNum)
            {
                Console.WriteLine("Too high! Try again.");
                intUserNum = int.Parse(Console.ReadLine());
            }
        } while (intUserNum != intRandomNum);

    Console.WriteLine("What Percent of the Apple would you like to eat?");
    double dblpercentApple = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("What Percent of the Banana would you like to eat?");
    double dblpercentBanana = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("You have " + (apple.Eat(dblpercentApple)) + "% of your apple and " + (banana.Eat(dblpercentBanana)) + "% of your banana left.");

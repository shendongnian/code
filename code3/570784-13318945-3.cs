    class FruitGarden
    {
     private Apple apple;
     private Banana banana;
     static void Main(string[] args)
     {
        FruitGarden fruitGarden = new FruitGarden();
        fruitGarden.EatFruits();
     }
     public void MakeFruits()
     {
        //Apple apple = new Apple();//You have already declared apple in this scope
        //apple.apple(1.5);//This is redundant, what you most likely want is to have this done in a constructor
        apple = new Apple(1.5);//this accesses the scoped apple, and uses the Apple constructor
        //Banana banana = new Banana();//same scopeing issue as apple
        banana = new Banana();
        banana.banana(3.5);//the banana class was not shown so I will leave this
     }
     public void EatFruits()
     {
        double dblpercent;
        MakeFruits();//now made properly with scope
        Console.WriteLine("You have an Apple and a Banana in your fruit garden.\n");
        Console.WriteLine("What Percent of the Apple would you like to eat?");
        dblpercent = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nWhat Percent of the Banana would you like to eat?");
        dblpercent = Convert.ToDouble(Console.ReadLine());
        Console.Write("You have ");
        apple.Eat(dblpercent);//Eat was never shown
        Console.Write("% of your apple, and ");
        banana.Eat(dblpercent);//Eat was never shown
        Console.Write("% of your banana left.");
        Console.ReadLine();
     }
    }

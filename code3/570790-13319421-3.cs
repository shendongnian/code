    class Program
    {
        private static FruitGarden myGarden;
        static void Main(string[] args)
        {
            //get a new garden
            myGarden = new FruitGarden();
            Console.WriteLine(myGarden.PlantFruit("banana")); 
            //returns "You grew one banana!"
            Console.WriteLine(myGarden.PlantFruit("apple")); 
            //returns "You grew one apple!"
            Console.WriteLine(myGarden.PlantFruit("orange")); 
            //returns "You can't grow that type of fruit!"
            EatFruits();
        }
        static void EatFruits()
        {
            //Now, let's just iterate through our fruit garden and eat all of that 
            //yummy fruit!
            for (int i = 0; i < myGarden.Fruits.Count; i++)
            {
                Fruit myFruitSnack = myGarden.Fruits[i];
                while (myFruitSnack.FruitSize > 0)
                {
                    Console.WriteLine(myFruitSnack.TakeBite());
                }
            }
            Console.ReadLine();
        }
    }
    //We could make this virtual or an interface, but I'll leave that out for now.
    public class Fruit
    {
        private int fruitSize;
        public int FruitSize
        {
            get
            {
                return this.fruitSize;
            }
        }
        public Fruit(int size)
        {
            this.fruitSize = size;
        }
        //The size of the fruit is an internal property. You can see how 
        //big it is, of course, but you can't magically make a fruit smaller
        //or larger unless you interact with it in a way that is allowable
        //according to the current known laws of the universe and agriculture. 
        //I.E, you can take a bite :)
        public string TakeBite()
        {
            if (this.fruitSize > 0)
            {
                this.fruitSize -= 1; //or any other value you decide to use
            }
            if (this.fruitSize > 0)
            {
                //again, there is so much more you can do here.
                return "You take a bite of the fruit!"; 
            }
            else
            {
                return "You take one more big bite and eat all of the fruit!";
            }
        }
    }
    public class Apple : Fruit
    {
        //Someday, you might want to overload these...
        public Apple(int fruitSize)
            : base(fruitSize)
        {
        }
    }
    public class Banana : Fruit
    {
        //Someday, you might want to overload these...
        public Banana(int fruitSize)
            : base(fruitSize)
        {
        }
    }
    class FruitGarden
    {
        //Public property of FruitGarden that contains all of the fruits it has "grown."
        public List<Fruit> Fruits { get; set; }
        public FruitGarden()
        {
            //Instantiate your list now.
            this.Fruits = new List<Fruit>();
        }
        //There are better ways to do this, but for the sake of your project we're
        //going to do something simple. We'll pass in a string representing the 
        //fruit type.
        public string PlantFruit(string fruitType)
        {
            //We're going to implement a simple factory here. Google 'factory pattern'
            //later and be prepared to spend a lot of time reading over the ideas
            //you're going to run into.
            switch (fruitType.ToLower())
            {
                case "apple":
                    this.Fruits.Add(new Apple(10));
                    break;
                case "banana":
                    this.Fruits.Add(new Banana(5));
                    break;
                default:
                    return "You can't grow that type of fruit!";
            }
            return "You grew one " + fruitType + "!";
        }
    }

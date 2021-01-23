    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog() { Age = 4 };
            //This approach (version A)
            Console.WriteLine(dog.DisplayDogYears());
            Console.ReadKey();
        }
       
    }
    public class Dog
    {
        public int Age { get; set; }
        public String DisplayDogYears()
        {
            return("The dog is {0} years old in human years.", Age * 7);
        }
    }

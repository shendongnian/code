    namespace ConsoleApplication4
    {
        public class car
        {
            //note the absence of static keyword..it means it is an instance method
            //note the virtual keyword..it means derived classes can override the behavior
            public virtual void wheel()
            {
                Console.WriteLine("The wheels of car are rolling");
            }
            
        }
    
        public class newmodel : car
        {
            //note the override keyword....it means newmodel overrides the wheel function
            public override void wheel()
            {
                //depending on your needs you may or maynot 
                // need to call the base class function first
                base.wheel();
                Console.WriteLine("And The new rims are rocking");
            }
    
        }
    
        class Program
        {
            static void Main()
            {
                //Instead of static methods you create a car object on
                //on which you invoke member functions
                car currentcar = new car();
                while (true)
                {
                    Console.WriteLine("Press A to Roll the Wheels baby");
                    Console.WriteLine("Press N to switch to new model");
                    char c = Convert.ToChar(Console.ReadLine());
                    switch (c)
                    {
                        case 'a':
                            {
                                currentcar.wheel();
                                break;
                            }
                        case 'n':
                            {
                                currentcar = new newmodel();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please Enter the Correct Input");
                                break;
                            }
    
                    }
                }
            }
        }
    }

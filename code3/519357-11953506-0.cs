       namespace ConsoleApplication4
    {
        public class car
        {
            public virtual void wheel()
            {
                Console.WriteLine("The wheels of car are rolling");
            }
            
        }
    
        public class newmodel : car
        {
            public override void wheel()
            {
                base.wheel();
                Console.WriteLine("And The new rims are rocking");
            }
    
        }
    
        class Program
        {
            static void Main()
            {
    
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

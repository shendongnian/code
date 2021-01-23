    namespace ConsoleApplication4 
    { 
       public abstract class car 
       { 
        public virtual void wheel() 
        { 
            Console.WriteLine("The wheels are rolling"); 
        } 
        public virtual void doors() 
        { 
            Console.WriteLine("The Doors are automatic"); 
        } 
        public virtual void engine() 
        { 
            Console.WriteLine("The engine of car is runing"); 
        } 
        public virtual void oil() 
        { 
            Console.WriteLine("the oil is full in tank"); 
        } 
       } 
       public class standardmodel : car
       {
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
             while (true) 
             { 
                Console.WriteLine("Press A to Roll the Wheels baby"); 
                Console.WriteLine("Press B to Open/Close the Doors"); 
                Console.WriteLine("Press C to Start the Car Engine"); 
                Console.WriteLine("Press D to Check the Oil in tank"); 
                Console.WriteLine("Press E to Rims/wheels"); 
                Console.WriteLine("Press F to Exit the vehicle"); 
                char c = Convert.ToChar(Console.ReadLine()); 
                Car standard = new standardcar(),
                    newModel = new newmodel();
                switch (c) 
                { 
                    case 'a': 
                        { 
                            standard.wheel(); 
                            break; 
                        } 
                    case 'b': 
                        { 
                            standard.doors(); 
                            break; 
                        } 
                    case 'c': 
                        { 
                            standard.engine(); 
                            break; 
                        } 
                    case 'd': 
                        { 
                            standard.oil(); 
                            break; 
                        } 
                    case 'e': 
                        { 
                            newModel.wheel(); 
                            break; 
                        } 
                    case 'f': 
                        { 
                            Environment.Exit(0); 
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

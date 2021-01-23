    using System;
    using System.Threading.Tasks;
    
    public class Program {
        public static void Main() {
            // use an Action delegate and named method
            Task task1 = new Task(new FindNorth(cell));
            // use an anonymous delegate
            Task task2 = new Task(new FindSouth(cell));
            // use a lambda expression and a named method
            Task task3 = new Task(new FindSouth(cell));
            // use a lambda expression and an anonymous method
            Task task4 = new Task(new FindEast(cell));
    
            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            Console.WriteLine("Main method complete. Press <enter> to finish.");
            Console.ReadLine();
        }
        
    }

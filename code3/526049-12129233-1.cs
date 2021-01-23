    using System;
    using System.Threading.Tasks;
    
    public class Program {
        public static void Main() {
            
            Task<Cell> task1 = new Task<Cell>(n => FindNorth((Cell)n), cell);
            Task<Cell> task2 = new Task<Cell>(n => FindSouth((Cell)n), cell);
            Task<Cell> task3 = new Task<Cell>(n => FindSouth((Cell)n), cell);
            Task<Cell> task4 = new Task<Cell>(n => FindEast((Cell)n), cell);
           
 
    
            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            Console.WriteLine("Main method complete. Press <enter> to finish.");
            Console.ReadLine();
        }
        
    }

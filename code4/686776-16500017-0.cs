    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                GameManager gameManager = new GameManager();
                gameManager.StartGame();
            }
    
     
            public class GameManager
            {
                System.Timers.Timer aTimer;
                int Parameter
                {
                    get;
                    set;
                }
                public GameManager()
                {
                   
                }
                public void StartGame()
                {
                   aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    // Set the Interval to 5 seconds.
                    aTimer.Interval = 1000;
                    aTimer.Enabled = true;
    
                    Console.WriteLine("Press \'q\' to quit the sample.");
                    Parameter = 200;
                    while (Console.Read() != 'q') 
                    {
                        Parameter =+ 10;
                    }
                }
                private void OnTimedEvent(object source, ElapsedEventArgs e)
                {
                    Parameter++;
                    Console.WriteLine("Hello World!" + Parameter.ToString());
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace avaragescore
    {
        class Program
        {
          
            static void Main(string[] args)
            {
                float quiz;
                float midterm;
                float final;
                float avrg=0;
            Start:
                Console.WriteLine("Please enter the Quize Score here");
                quiz = float.Parse(Console.ReadLine());
                if(quiz > 100)
                {
                    Console.WriteLine("You have entered wrong score please re-enter");
                    goto Start;
                }
                Start1:
                Console.WriteLine("Please enter the Midterm Score here");
                midterm = float.Parse(Console.ReadLine());
                if(midterm > 100)
                {
                    Console.WriteLine("You have entered wrong score please re- enter");
                    goto Start1;
                }
                Start3:
                Console.WriteLine("Please enter the Final Score here");
                final = float.Parse(Console.ReadLine());
                if(final > 100)
                {
                    Console.WriteLine("You have entered wrong Score Please re-enter");
                    goto Start3;
                }
                avrg = (quiz + midterm + final) / 3;
    
                if(avrg >= 90)
                {
                    Console.WriteLine("Your Score is {0} , You got A grade",avrg);
                }
                else if (avrg >= 70 && avrg < 90)
                {
                    Console.WriteLine("Your Score is {0} , You got B grade", avrg);
                }
                else if (avrg >= 50 && avrg < 70)
                {
                    Console.WriteLine("Your Score is {0} , You got C grade", avrg);
                }
                else if (avrg < 50)
                {
                    Console.WriteLine("Yor Score is {0} , You are fail", avrg);
                }
                else
                {
                    Console.WriteLine("You enter invalid Score");
                }
                Console.ReadLine();
            }
        }
    }

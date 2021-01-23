    class Program
        {   
    
            static void Main(string[] args)
            {   //here we declare the variables and the 2 arrays for the main method
    
                int perfecto = 100;
                string input;
                string student = string.Empty;
                int score = 0;            
    
    
                //this will be the introduction for the program nice and friendly.
                Console.WriteLine("Welcome to the Test score calculator!!");
                Console.Write("\nPlease Input your name and your score, seperated by a space and Press Enter: ");
                input = Console.ReadLine();
    
                //SPLIT METHOD ACTIVATED.. here we call the split method 
                SplitMethod(input, ref student, ref score);
    
                //Here we call the output           
                Output(student, score, perfecto);
    
                Console.ReadLine();
            }
            //Here is the split method. this will take the two kinds of data and split them into 2 arrays
            //the string and the int seperate so that its easyer to make calculations. 
            //also we referenced these arrays 
            static void SplitMethod(string input, ref string student, ref int score)
            {
                char [] rules = { ' ', '\r' };
                string [] splitArray = input.Split(rules);
    
                //here is the actual split
                if(splitArray.Length>1)
                {
                    student = splitArray[0];
                    int.TryParse(splitArray[1], out score);
                }
            }     
    
            static void Output(string student, int score, int perfecto)
            {         
                //here is the added if statement for the perfect score scenario 
                if (score > perfecto)
                {
                    //here is the output incase someone scores a perfect game
                    Console.WriteLine("\n{0}'s score was {1}*...Congrats {2} you qualify for the TEAM!!!", student, score, student);
                }
                else
                {
                    //and if they dont it displayes here.
                    Console.WriteLine("\nSorry {0}, {1} is not good enough. \nIm afraid you dont qualify, but keep it up!", student, score);
                }
            }
        }

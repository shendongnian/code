            try
            {
                //Function to Perform
            }
            catch (Exception e)
            {
             //You can display what error occured in Try block, with exact technical spec (DivideByZeroException)
                throw; 
                // Displaying error through signal to Machine, 
                //throw is usefull , if you calling a method with try from derived class.. So the method will directly get the signal                
            }
            finally  //Optional
            {
                //Here You can write any code to be executed after error occured in Try block
                Console.WriteLine("Completed");
            }

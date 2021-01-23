    using System;
    namespace array_sample
    {
        class StudentData
        {
            static void Main(string[] args)
            {
                String temp;
                int limit = 5; //the number length limit
                Student[] ourStudents = new Student[24];   
                // declared an array of stduent objects 
    
                for (int i = 0; i < ourStudents.length; i++)
                {
                    Console.WriteLine("Enter your Student Number :");
                    temp = Console.ReadLine();
                    If (temp.length = limit)
                    {
                      ourStudents[i].Number = Int32.Parse(Console.ReadLine()); 
                      // make sure to convert to integer
    
                      Console.WriteLine("Enter your Name :");
                      ourStudents[i].Name = Console.ReadLine(); 
                    }
                    Else
                    {
                      Console.WriteLine("Number Can only be 5 digits");
                      if (i > 0)
                         {i = i - 1;}
                      else
                         {i = 0;}
                    }
                } // end of input loop
    
                foreach (int i in ourStudents)
                {
                    Console.WriteLine("Number : " + ourStudents[i].Number +'\t' + "Name :"
                                      + ourStudents[i].Name);
                }// end of output loop
    
                Console.ReadLine();
            }
        }// end of class
    } // end of namespace
    
     

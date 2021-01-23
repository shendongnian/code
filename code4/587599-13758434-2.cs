    using System;
    namespace array_sample
    {
        class StudentData
        {
            static void Main(string[] args)
            {
                Student[] ourStudents = new Student[24];   
                // declared an array of stduent objects 
    
                for (int i = 0; i < ourStudents.length; i++)
                {
                    Console.WriteLine("Enter your Student Number :");
                    ourStudents[i].Name = Int32.Parse(Console.ReadLine()); 
                    // make sure to convert to integer
    
                    Console.WriteLine("Enter your Name :");
                    ourStudents[i].Name = Console.ReadLine(); 
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
    
     

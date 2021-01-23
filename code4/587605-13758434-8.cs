    using System;
    namespace array_sample
    {
        class StudentData
        {
            static void Main(string[] args)
            {
                Regex num = new Regex(@"^\d{5}$");
                Student[] ourStudents = new Student[24];   
                // declared an array of stduent objects 
    
                for (int i = 0; i < 24; i++)
                {
                    Console.WriteLine("Enter your Student Number :");
                    Match n = num.Match(Console.ReadLine());
                    if (n.Value != "")
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
    
                for(i=0; i<24; i++)
                {
                    Console.WriteLine("Number : " + ourStudents[i].Number +'\t' + "Name :"
                                      + ourStudents[i].Name);
                }// end of output loop
    
                Console.ReadLine();
            }
        }// end of class
    } // end of namespace
    
     

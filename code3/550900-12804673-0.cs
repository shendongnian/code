    static void Main(string[] args)  
                {  
        try
        {
                    int accode ;  
                    Student student = new Student() ;  
                    Course course = new Course() ;  
                    Grade grade = new Grade() ;  
                    do  
                    {  
                        Console.WriteLine(" 1.  Input Student information");  
    ...
                        Console.WriteLine(" 0.  Exit");  
                        Console.WriteLine(" Please select a choice from 0-8");  
                        accode = Console.ReadLine();  
                        switch (accode)  
                        {
        ...  
                        }  
                    } while (accode != 0);   
        }
        catch (Exception Ex)
        {
           Console.Writeline("Exception: " + ex.Message);
        }
                    Console.ReadKey();  
                } 
  

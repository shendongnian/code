    using(FileStream s = new FileStream("Scheduler.txt",FileMode.Append,FileAccess.Write))
    {    
        using(StreamWriter w = new StreamWriter(s))
        {
            Console.WriteLine("Enter the Name of the Person To Be Met:");
            string name = Console.ReadLine();
            w.WriteLine();//move to the next line first  
            w.Write(name);
        }                    
    }
   

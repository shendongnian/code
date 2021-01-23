    // Convention in C# is to use properties instead of fields for something like this
    // also, having the class name in the field name is redundant
    public class Instance
    {
        public string Name {get;set;}
        public string Stop {get;set;}
    
        public string Restart {get;set;}
        public string Backup {get;set;}
    } 
    
    public static void Main(string[] args)
    {
        List<Instance> items = new List<Instance>();
        // the using block will close the file handle
        using (System.IO.StreamReader file = new System.IO.StreamReader(@"C......"))
        {
            while(true)
            {
                String name = file.ReadLine(), stop = file.ReadLine(), restart = file.ReadLine(), backup = file.ReadLine();
                if (name == null || stop == null || restart == null || backup == null)
                    break; // I didn't test it, but this should work for determining the end of the file
                items.Add(new Instance(){
                   Name = name,
                   Stop = stop,
                   Restart = restart,
                   Backup = backup
                });
            }
        }
    }

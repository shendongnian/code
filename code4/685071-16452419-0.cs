    using System.Collections.Generic; // Add this to the rest of 'usings' 
    public static void Main(string[], args)
    {
        // Create a new stream to read the file
        StreamReader SReader = new StreamReader("C:\file.txt");
        // Create a list of 'Instance' class instances
        List<Instance> AllInstances = new List<Instance>();
        // Keep reading until we've reached the end of the stream
        while(SReader.Peek() > 0)
        {
             // Read the line
             string CurrentLine = SReader.ReadLine(); // if you call this multiple times in this loop you proceed multiple lines in the file..
             // Create an new instance of the 'Instance' class
             Instance CurrentInstance = new Instance();
             // Assign the 'Name' property
             CurrentInstance.Name = CurrentLine;
             // Add class instance to the list
             AllInstances.Add(CurrentInstance);
        }
        // Close the stream
        SReader.Close();
    }

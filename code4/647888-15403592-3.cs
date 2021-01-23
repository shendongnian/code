    private static void Deserialize() 
    { 
        // Declare the hashtable reference.
        SortedList<string, string> addresses = null;
    
        // Open the file containing the data that you want to deserialize.
        FileStream fs = new FileStream(@"C:data.dat", 
            FileMode.Open);
        try 
        {
            BinaryFormatter formatter = new BinaryFormatter();
    
            // Deserialize the hashtable from the file and 
            // assign the reference to the local variable.
            addresses = (SortedList<string, string>) formatter.Deserialize(fs);
        }
        catch (SerializationException e) 
        {
            Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally 
        {
            fs.Close();
        }
        // To prove that the table deserialized correctly, 
        // display the key/value pairs.
        foreach (var de in addresses) 
        {
            Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
        }
        Console.ReadLine();
    }

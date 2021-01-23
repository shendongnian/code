    public void WriteToFile(string filename)
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None); // filename parameter instead of fixed path
            formatter.Serialize(stream, this); // class instance instead of filename parameter
            stream.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unable to serialize Expenses: {0}", ex.Message);
        }
    }
    public static EIR ReadFromFile(string filename)
    {
        EIR iRost = new EIR();
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read); // filename parameter instead of fixed path
            iRost = (EIR)formatter.Deserialize(stream);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unable to deserialize Expenses: {0}", ex.Message);
        }
        return iRost;            
    }            

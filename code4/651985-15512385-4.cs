    public static void Serialize(byte[,] t)
    {
        using(Stream stream = File.Open("Test.osl", FileMode.Create))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, t);
        }
    }
    public static byte[,] Deserialize()
    {
        using(Stream stream = File.Open("Test.osl", FileMode.Open))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            return (int[,])bformatter.Deserialize(stream);
        }
    }
        

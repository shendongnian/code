    Player p = new Player(); 
    p.Name = "Something"
    ...
    try
    {
        using (Stream stream = File.Open("save.dat", FileMode.Create))
        {
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, p);
        }
    }
    catch (IOException)
    {
    }

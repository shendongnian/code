    Random random = new Random();
    Console.WriteLine("Please enter the name of the numbers file");
    string fileLotto = Console.ReadLine();
    string fileName = "../../" + fileLotto + ".txt";
    //creating the lotto file
    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
    Console.WriteLine("File created");
    fs.Close();
    
    StreamWriter sw = new StreamWriter(fileName);
    for(int i = 0; i < 6; i++)
    {
        for(int j = 0; j < 7; j++)
        {
            //Console.Write(random.Next(1, 49));
            sw.Write(random.Next(1, 49) + " " );
        }
        Console.WriteLine();
    }
    sw.Close();

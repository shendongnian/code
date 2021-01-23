    int AccNum;
    using(FileStream myfile = new FileStream("C:\\bankin.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
    using(StreamReader rd = new StreamReader(myfile))
    using (StreamWriter wt = new StreamWriter(myfile))
    {
        int a = Convert.ToInt32(rd.ReadLine());
        AccNum = a;
        a += 1;
        wt.WriteLine(Convert.ToString(a));
        Console.WriteLine(rd.ReadLine());
    }

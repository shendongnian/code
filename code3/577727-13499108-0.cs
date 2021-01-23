    List<string[]> stringList = new List<string[]>();
    for (int i = 0; i < 12; i++)
    {
        using (StreamReader sr = new StreamReader(path + "words" + (i+3) + ".txt"))
            {
                String strTemp = sr.ReadLine();
                stringList.Add(strTemp.Split(' '));
            }
    }

    static void ReadFile()
    {
        using(StreamWriter writer = new StreamWriter(@"Data.csv"))
        {
            string line = null;
            line = reader.ReadLine();
            while(null!= (line = reader.ReadLine())
                    {
                        string[] values = line.Split(',');
                        string name = values[0];
                        int age = int.Parse(values[1]);
                    }
            Person person = new Person(name, age);
        }
    }

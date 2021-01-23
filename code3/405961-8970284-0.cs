        using (StreamWriter writer = new StreamWriter("asd.csv", false, Encoding.UTF8))
        {
            writer.WriteLine("Id;City");
            writer.WriteLine("1;Montréal");
            writer.WriteLine("2;Québec");
        }

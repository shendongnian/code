    System.IO.StreamReader file = new System.IO.StreamReader("data.txt");
    List<string> Spec = new List<string>();
    while (!file.EndOfStream)
    {
        if(file.ReadLine().Contains("Spec")) 
        {
            Spec.Add(s.Substring(5, s.Length - 5));
        }
    }

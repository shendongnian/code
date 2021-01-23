    System.IO.StreamReader file = new System.IO.StreamReader(@"data.txt");
    List<String> Spec= new List<String>();
    while (file.EndOfStream != true)
    {
        string s = file.ReadLine();
        Match m = Regex.Match(s, "(?<=Spec\s)(.)+");
        if (m.Success)
        {
            Spec.Add(m.ToString());
        }
        s = String.Empty; // do not forget to free the space you occupied.
    }

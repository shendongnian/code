    string s1 = "ABC123";
    string s2 = "we ABC123 weew";
    string s3 = "ABC435";
    string s4 = "Can ABC Oh say can You see";
    List<string> list = new List<string>() { s1, s2, s3, s4 };
    Regex regex = new Regex(@".*(?<=.*ABC(?!.*123.*)).*");
    Match m = null;
    foreach (string s in list)
    {
        m = regex.Match(s);
        if (m != null)
            Console.WriteLine(m.ToString());
    }

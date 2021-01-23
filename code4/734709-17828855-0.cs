    public void RandomChar(string s) {
        Random r = new Random();
        int i = r.Next(s.Length);
        Console.WriteLine(s[i] + " - " + (i+1));
    }

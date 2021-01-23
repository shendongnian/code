    List<List<int>> scores = new List<List<int>>();
    scores.Add( new List<int>() );
    using( StreamReader section1read = File.OpenText("Section1.txt"))
    {
        string line;
        while ((line = section1read.ReadLine()) != null)
        {
            scores[0].Add(int.Parse(line));
        }
    }

    String line = null;
    var input = new List<int>();
    int count = 0;
    var vectors = new List<Vector3>();
    while ((line = file.ReadLine()) != null)
    {
        int i = 0;
        if( int.TryParse(line,out i))
        {
           input.Add(i);
           count++;
           if (count % 3 == 0)
           {
              vectors.Add(new Vector3(input[count-2], input[count-1], input[count]);
           }
        }
    }

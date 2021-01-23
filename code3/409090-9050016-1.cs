    string sequence = "12345";
    int[] ziffern = new int[sequence.Count()];
    int bar;
    for (int i = 0; i < sequence.Count(); i++)
    {
        if (!int.TryParse(sequence.ElementAt(i).ToString(), out bar))
        {
        //Do something to correct the problem
        }
        else
        {
           ziffern[i] =  bar;
        }
    }

    string input = ....
    for(int i = 0 ; i < input.Length ; i += Char.IsSurrogatePair(input,i) ? 2 : 1)
    {
        int x = Char.ConvertToUtf32(input, i);
    	Console.WriteLine("U+{0:x4}", x);
    }

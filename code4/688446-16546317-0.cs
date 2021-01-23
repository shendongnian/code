    byte[] output = Convert.FromBase64String(input);
    Console.WriteLine(output.Length);
    int rslt = 0;
    for (int i = 0; i < output.Length; ++i)
    {
        rslt <<= 8;
        rslt += output[i];
    }
    Console.WriteLine(rslt);
    Console.WriteLine((double)rslt / 1150.78);

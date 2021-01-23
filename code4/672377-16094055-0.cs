    var chars = mutate.ToCharArray();     // convert to char[]
    for (int i = 0; i < 4; i++)
    {
        int MutProbablity = random.Next(1, 1000);
        if (MutProbablity == 5)
        {
            if (chars[i] == '0')
            {
                chars[i] = '1';
            }
            else if (chars[i] == '1')
            {
                chars[i] = '0';
            }
        }
    }
    mutate = new String(chars);    // convert to back to string

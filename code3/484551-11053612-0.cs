    Random rand = new Random(new DateTime().Millisecond);
    String[] possibilities = {"a","b","c","d","e","f","g","h","i","j","k",
        "l","n","p","q","r","s","t","u","v","x","y","z","0","1","2","3","4",
        "5","6","7","8","9"};
    for (int i = 0; i < 1000000; ++i)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int j = 0; j < 8; ++j)
        {
            sb.Append(possibilities[rand.Next(possibilities.Length)]);
        }
        if (!databaseContains(sb.ToString()))
            databaseAdd(sb.ToString());
        else
            --i;
    }

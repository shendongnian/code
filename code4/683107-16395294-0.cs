    System.IO.StreamReader file = new System.IO.StreamReader(FILE_PATH);
    int skipLines = 5;
    for (int i = 0; i < skipLines; i++)
    {
        file.ReadLine();
    }
    // Do what you want here.

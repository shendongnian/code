    string words
    string outputwords = words;
    int CharsWithoutSpace = 0;
    for (int i = 0; i < outputwords.Length; i++)
    {
         if (outputwords[i] == ' ')
         {
             CharsWithoutSpace = 0;
         }
         else
         {
             CharsWithoutSpace++;
             if (CharsWithoutSpace >= 20)
             {
                 outputwords = outputwords.Insert(i + 1, Environment.NewLine);
                 CharsWithoutSpace = 0;
             }
        }
    }
    Console.WriteLine(outputwords);

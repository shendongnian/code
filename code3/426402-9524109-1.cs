    ArrayList guesses = new ArrayList(); //This is the ArrayList
    int position;
    for (int i = 0; i < guesses.count; i++)
    {
       if(i % 4)
       {
         Console.WriteLine(string.Format("{0}{1}{2}{3}", guesses[i - 3], guesses[i - 2],
                  guesses[i - 1], guesses[i]);
         position = i;
       }
       else
       {
           if(i == guesses.count)
           {
              for(int j = position; j > 0 ; j--)
              {
                  Console.Write(guesses[i - j]);
              }
           }
       }
    }

    long lastEvent = 0;
    int lastNum = 0;
    int taps = 0;
    
    eventListener(KeyEventArgs e)
    {
        if (e.Value == lastNum)
        {
             if ((DateTime.Now.ToFileTimeUtc() - lastEvent) < AppropriateTimeLimit)
             {
                  taps++;
             }
             else
             {
                  GetLetter(taps, lastNum);
                  lastEvant = DateTime.Now.ToFileTimeUtc();
                  taps = 0;
             }
        }
        else
        {
                  GetLetter(taps, lastNum);
                  lastEvant = DateTime.Now.ToFileTimeUtc();
                  taps = 0;
                  lastNum = e.Value;
        }
    }
    char GetLetter(int taps, int num)
    {
         if (num == 1)
             return punctuationVals[taps % length -1];
         else if (num == 0)
             return ' '; //from what I remember 0 was for spaces on most phones
         else
         {
             int val;
             if (taps > 3)
                 val = taps % 4; // old phones wrap around back to the first char if I press the key 5 times
             else 
                 val = taps;
              return values[num][val];
         }
    }
    char[][] values = new char[9][4]; // statically code all of your chars in these arrays
    char[] punctuationVals = new char[idkHowMany];

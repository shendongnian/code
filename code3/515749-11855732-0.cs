    static int max_alternate(int[] numbers)
    {
      int maxCount = 0;
      int count = 0;
      int dir = 0; // whether we're going up or down
      for (int j = 1; j < numbers.Length; j++)
      {
          Console.WriteLine(numbers[j]);
          // don't know direction yet
          if (dir == 0)
          {
              if (numbers[j] > numbers[j-1])
              {
                  count += 2; // include first number
                  dir = 1; // start low, up to high
              }
              else if (numbers[j] < numbers[j-1])
              {
                  count += 2;
                  dir = -1; // start high, down to low
              }
              else
              {
                  count = 0;
              }
          }
          else
          {
              if (dir == -1 && numbers[j] > numbers[j-1])
              {
                  count += 1;
                  dir = 1; // up to high
              }
              else if (dir == 1 && numbers[j] < numbers[j-1])
              {
                  count += 1;
                  dir = -1; // down to low
              }
              else 
              {
                  Console.WriteLine("not found");
                  // sequence broken
                  if (count > maxCount)
                  {
                      maxCount = count;
                  }
                  count = 0;
                  dir = 0;
              }
          }
      }
      // final check after loop is done
      if (count > maxCount)
      {
          maxCount = count;
      }
      return maxCount;
    }

You would just reset i and resize the array
    for (int i = 0; i <= newData.Length; i++)
    {
        if (condition)
        {
           //do something with the first line
        }
        else
        {
          // Resize array
          string[] newarr = new string[newData.Length - 1 - i];
          // Copy data
          for (int ii = 0; ii < newarr.Length; ii++, i++)
          {
              newarr[ii] = newData[i];
          }
          // Set array
          newData = newarr;
          // Restart loop
          i = 0;
        }
    }

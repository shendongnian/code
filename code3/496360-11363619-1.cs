    private static bool IsStopChar(char c)
    {
      switch (c)
      {
        case ' ':
        case ',':
        case '.':
          return false;
        default:
          return true;
      }
    }
    //...
    
      while (!IsStopChar(txtSource.Text[startPos]))
      {
        //...
      }

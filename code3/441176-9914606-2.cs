        int j = given.Length - 1;
        for (; j >= 0; j--)
        {
          char c = given[j];
          if (c < '0' || c > '9')
          {
            break;
          }
        }
        var first = given.Substring(0, j + 1);
        var rest = given.Substring(j + 1);

        foreach (object item in cmb.Items)
        {
          string[] str = item.ToString().split(new char[] {' '}
    , StringSplitOptions.RemoveEmptyEntries);
          if(str[1] == "Banana")
          {
               Console.Write(str[0]);
          }
        }

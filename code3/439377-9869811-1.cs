    public static string IncNumberBeforeAt(string text)
    {
      int lastAt = text.LastIndexOf('@');
      if (lastAt != -1)
      {
        int pos = lastAt - 1;
        string num = "";
        while (char.IsNumber(text[pos]))
        {
          num = text[pos] + num;
          pos--;
          if (pos < 0)
            break;          
        }
        int numInc = int.Parse(num) + 1;
        return text.Replace(num.ToString() + "@", numInc.ToString() + "@");
      }
      else
      {
        return text;
      }
    }

    public string HTMLEncodeSpecialChars(string text)
    {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach (char c in text){
        if(c>127) // chars not in ASCII
          sb.Append(String.Format("&#{0};",(int)c));
        else
          sb.Append(c);
      }
      return sb.ToString();
    }

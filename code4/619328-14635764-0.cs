    string text;
    string[] a;
    
    if (Clipboard.ContainsText())
       {
          text = Clipboard.GetText(TextDataFormat.Text);
    
          //  the following could have been done simpler with
          //  a Regex, but the regular expression would be not
          //  exactly simple
    
          if (text.Length > 1)
              {
                  //  unify all line breaks to \r
                  text = text.Replace("\r\n", "\r").Replace("\n", "\r");
    
                  //  create an array of lines
                  a = text.Split('\r');
    
                  //  join all trimmed lines with a space as separator
                  text = "";
                       
                  //  can't use string.Join() with a Trim() of all fragments
                  foreach (string t in a)
                  {
                      if (text.Length > 0)
                          text += " ";
                      text += t.Trim();
                  }
              
                Clipboard.SetDataObject(text, true);
              }
        }

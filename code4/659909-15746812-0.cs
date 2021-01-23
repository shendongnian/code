    private void Play(List<string> arraySrc, List<string> arrayTitle, 
                       List<string> arrayImage, List<string> arrayTags)
    {
        ...
        string[] tags = arrayTags.ToArray();
        string[] split;
        string aT="arrayTags";
        string aV=string.empty;
        foreach (string item in tags)
        {
          if (item.IndexOf(',') != -1)
          {
             split = item.Split(',');
             foreach (string s in split)
             {
                aV +="\""+ String.Concat("<span class=label>", s, "</span>"))+"\",";
             }
          }
        }
        ClientScript.RegisterArrayDeclaration(aT,aV);
    }

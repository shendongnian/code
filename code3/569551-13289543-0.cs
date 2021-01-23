    public void ListFiles(List<string> mfiles)
    {
       for(int i=0; i < mfiles.length; i++)
       {
          Panel1.Controls.Add(new LiteralControl("<a href=\"/Files/" + mfiles[i] + "\">" + mfiles[i] + "</a>" ));
          Panel1.Controls.Add("<br />");
       }
    }

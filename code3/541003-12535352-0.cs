        List<string> MessageList; // populated from data source
        Label lblHtmlOutput = new Label();
        //StringBuilder sb = new StringBuilder();
        //foreach (var item in MessageList)
        //{
        //    sb.Append(item + "<br/><br/>");
        //}
        //sb.Remove(sb.Length - 11, sb.Length - 1);
        string list = string.Join("<br/><br/>", MessageList);

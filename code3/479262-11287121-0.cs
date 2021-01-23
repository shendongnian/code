    protected void SubmitMessages()
    {
        string[] lines = MessagesTextbox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        string output = "<ul>";
        foreach (string message in lines)
        {
            if (!message.Equals(""))
            {
                output += "<li>";
                output += message;
                output += "</li>";
            }
        }
        output += "</ul>";
        messagesDiv.InnerHtml = output;
        //string messagesFileLocation = AppDomain.CurrentDomain.BaseDirectory + "/mesages.xls";
        string messagesFileLocation = "D:\\WebApp\\messages.xml";
        FileStream fs = File.Open(messagesFileLocation, FileMode.Create, FileAccess.Write);
        if (lines.Length != 0)
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("<Messages>");
                foreach (string message in lines)
                {
                    if (!message.Equals(""))
                    {
                        sw.WriteLine("\t<message>" + message + "</message>");
                    }
                }
                sw.WriteLine("</Messages>");
            }
        }
    }

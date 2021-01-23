    tuitDisplayTextBox.Text = "";
    IEnumerable<string> lines = 
        File.ReadAllLines(Server.MapPath("~") +"/App_Data/tuitterMessages.txt");
    StringBuilder sb = new StringBuilder
    foreach (string line in lines)
    {
        if (line.Contains(searchTextBox.Text))
        {
            sb.AppendLine(line);
        }
    }
    tuitDisplayTextBox.Text = sb.ToString();

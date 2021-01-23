    tuitDisplayTextBox.Text = "";
    string[] lines =
        File.ReadAllLines(Server.MapPath("~") +"/App_Data/tuitterMessages.txt");
    StringBuilder sb = new StringBuilder
    for (int i = 0; i < lines.Length; i++)
    {
        if (lines[i].Contains(searchTextBox.Text))
        {
            sb.AppendLine(lines[i]);
        }
    }
    tuitDisplayTextBox.Text = sb.ToString();

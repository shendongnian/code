    protected void submitDisplay_Click(object sender, EventArgs e)
    {
        displayText.InnerHtml = "";
        int index = folderNames.IndexOf(DropDownList.Text); //drop down box
        foreach (Char c in textBox.Text)
        {
            if(c == ' ')
            {
                displayText.InnerHtml += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            else
            {
                displayText.InnerHtml += "<img src = 'Alphabets/" + folderNames[index] + "/" + filePrefixes[index] + c + fileSuffixes[index] + ".gif' />";
            }
        }
    }

    private const string OPEN_TAG = "!#";
    private const string CLOSE_TAG = "#!";
    private void Parse(string s)
    {        
        int tagOpenIndex = 0;
        int tagCloseIndex = 0;
        tagOpenIndex = s.IndexOf(OPEN_TAG);
        string tag = string.Empty;
        while (tagOpenIndex >= 0)
        { 
            //Write everything before current tag opening 
            Response.Write(s.Substring(tagCloseIndex, tagOpenIndex));
            //Find where current tag is closing 
            tagCloseIndex = s.IndexOf(CLOSE_TAG, tagOpenIndex);
            //Get tag name
            tag = s.Substring(tagOpenIndex, tagCloseIndex - tagOpenIndex + 1);
            //Parse tag and create asp.net controls. Let's say this is a text box
            //You'll need to figure out where to put this and such
            //And also how to keep track of different control IDs so you can use these later.
            TextBox t = new TextBox();
            t.ID = "Generate some ID";
            Form.Controls.Add(t);
            //Get the index of next open tag
            tagOpenIndex = s.IndexOf(OPEN_TAG, tagCloseIndex);
        }
    }

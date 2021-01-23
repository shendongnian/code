    public static int FindTheWidth(object sender)
    {
        DropDownList senderComboBox2 = (DropDownList)sender;
        var width = senderComboBox2.Width;
    
        double doubleValue = width.Value;
        int width2 = (int)doubleValue;
        int vertScrollBarWidth = 2;
    
        int newWidth;
        foreach (ListItem s in ((DropDownList)sender).Items)
        {
            newWidth = width2 + vertScrollBarWidth;
            if (width2 < newWidth)
            {
                width2 = newWidth;
            }
        }
        senderComboBox2.Width = width2;
        return width2;
    }

        string[] item = itemArray.Split('~');
        if (item.Length == 3)
        {
            tbCM.Text = item[0].TrimStart(',');
            tbCode.Text = item[1];
            tbAmt.Text = item[2];
        }
        else
        {
            // handle bad input
        }

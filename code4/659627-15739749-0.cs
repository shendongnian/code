            int i = 1;
            if (ViewState["i"] == null)
            {
                ViewState["i"] = i;
            }
            else
                i = (int)ViewState["i"];
            PlaceHolder1.Controls.Clear();
            for (int j = 1; j <= i; j++)
            {
                TextBox TextBox = new TextBox();
                TextBox.ID = "TextBox" + j.ToString();
                PlaceHolder1.Controls.Add(TextBox);
            }
            ViewState["i"] = i + 1;

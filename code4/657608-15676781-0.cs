                TextBox txt = new TextBox();
                txt.ID = "New_txt";
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Text = dt.Rows[0]["message"].ToString();
                txt.Width = 802;
                txt.Height = 450;
                txt.ReadOnly = true;
                PlaceHolder1.Controls.Add(txt);

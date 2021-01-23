          RichTextBox[] txt = new RichTextBox[15];
            for (int i = 0; i < 15; i++)
            {
                txt[i] = new RichTextBox();
                txt[i].Text = "";
                if (i > 0)
                {
                    txt[i].Left = txt[i - 1].Right;
                }
                this.Controls.Add(txt[i]);
            }

            int width = 69;
            int height = 10;
            int spacing = 0;
            TextBox[] subAmt = new TextBox[12];
            for (int i = 0; i <= 11; ++i)
            {
                subAmt[i] = new TextBox();
                subAmt[i].Size = new Size(width, height);
            // mycode
                height = subAmt[i].Height;
            // ***
                subAmt[i].Margin = new Padding(3);
                subAmt[i].Location = new Point(279, (i * height) + spacing); // <-- this is should space it out but does not
                this.Controls.Add(subAmt[i]);
            }

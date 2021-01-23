     System.Windows.Forms.TextBox[,] textbox = new System.Windows.Forms.TextBox[column, row];
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    textbox[i, j] = new System.Windows.Forms.TextBox();
                    textbox[i, j].Size = new Size(80, 20);
                    textbox[i, j].Name = "textbox_" + i + "_" + j;
                    textbox[i, j].Location = new System.Drawing.Point((i * 80) + 20, (j * 20) + 30);
                    textbox[i, j].Visible = true;
                    Controls.Add(textbox[i, j]);
                      //new added
                    dictionaryTextBox.Add (textbox[i, j].Name, textbox[i, j]);
                }
            }

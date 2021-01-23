            for (int i = 0; i < richboxes.Length; i++)
            {
                richboxes[i] = new RichTextBox(); // Instance the TextBox
                Controls.Add(richboxes[i]);
                richboxes[i].Location = new System.Drawing.Point(14, y);
                richboxes[i].Name = "richTextBox" + (12 + j);
                richboxes[i].Size = new System.Drawing.Size(671, 68);
                richboxes[i].TabIndex = 41 + j;
                richboxes[i].Text = "";
                y += 70;
                j++;
            }

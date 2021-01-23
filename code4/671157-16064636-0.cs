        private void button1_Click(object sender, EventArgs e)
        {
            List<Label> labels = new List<Label>();
            for (int i = 0; i <= 5; i++)
            {
                Label label = new Label();
                label.Name = "lbl" + i;
                label.Text = "Test text";
                mainPanel.Controls.Add(label);
            }
            List<RichTextBox> textBoxes = new List<RichTextBox>();
            for (int col = 0; col < 2; col++)
            {
                for (int row = 0; row < 2; row++)
                {
                    RichTextBox richTB = new RichTextBox();
                    richTB.Name = "textBox" + col + row;
                    tableLayoutPanel1.Controls.Add(richTB);
                    tableLayoutPanel1.SetColumn(richTB, col);
                    tableLayoutPanel1.SetRow(richTB, row);
                }
            }
        }

    private void Form1_Load(object sender, EventArgs e)
            {
                if (panel1.Height % 3 == 0)
                {
                    SetLabels();
                }
                else
                {
                    while (panel1.Height % 3 != 0)
                    {
                        panel1.Height++;
                    }
    
                    SetLabels();
                }
                
            }
            private void SetLabels()
            {
                panel1.Controls["label1"].Location = new Point(1, 1);
                panel1.Controls["label1"].Height = (panel1.Height / 3);
                panel1.Controls["label1"].Width = panel1.Width;
                label1.BackColor = Color.Red;
                panel1.Controls["label2"].Location = new Point(1, label1.Height);
                panel1.Controls["label2"].Height = label1.Height;
                panel1.Controls["label2"].Width = panel1.Width;
                label2.BackColor = Color.Purple;
                panel1.Controls["label3"].Location = new Point(1, label2.Height + label1.Height);
                panel1.Controls["label3"].Height = label1.Height;
                panel1.Controls["label3"].Width = panel1.Width;
                label3.BackColor = Color.Beige;
            }

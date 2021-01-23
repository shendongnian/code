    private void button1_Click(object sender, EventArgs e)
    {
        int matrSize = 4;
        int counter = 0;
        TextBox[] MatrixNodes = new TextBox[matrSize * matrSize];
        for (int i = 0; i < matrSize; i++)
        {
            for (int j = 0; j < matrSize; j++)
            {
                var tb = new TextBox();
                Random r = new Random();
                int num = r.Next(1, 1000);
                MatrixNodes[counter] = tb;
                tb.Name = "Node_" + MatrixNodes[counter];
                tb.Text = num.ToString();
                tb.Location = new Point(172 + (j * 150), 32 + (i * 50));
                tb.Visible = true;
                this.Controls.Add(tb);
                counter++;
            }
            counter = 0;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
            for (int x = 0; x < btn.GetLength(0); x++)
            {
                for (int y = 0; y < btn.GetLength(1); y++)
                {
                    btn[x, y].BackColor = Color.Black;
                }
            }
    }

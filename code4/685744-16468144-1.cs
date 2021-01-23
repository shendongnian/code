    private void button1_Click(object sender, EventArgs e)
    {
        string pngPath = @"E:\Color Pallet.png";
        tableLayoutPanel1.Controls.Clear();
        using (var bitmap = new Bitmap(pngPath))
        {
            for (int i = 0; i < 256; i++)
            {
                var color = bitmap.GetPixel(5 + (10*(i%16)), 5 + (10*(i/16)));
                tableLayoutPanel1.Controls.Add(new Panel {Dock = DockStyle.Fill, BackColor = color}, i % 16, i / 16);
            } 
        }

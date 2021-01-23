    void picBoxs_Click(object sender, EventArgs e)
    {
        var box = sender as PictureBox;
        int i = Array.IndexOf(picBoxs, box);
        int columnCount = 3;
        int row = i / columnCount;
        int col = i % columnCount;
        Messagebox.Show(string.Format("[{0}][{1}]", row, col));       
    }

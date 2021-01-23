    protected override void OnDragDrop(DragEventArgs e)
    {
        var bmp = (Bitmap)e.Data.GetData(typeof(Bitmap));
        var pb = new PictureBox();
        pb.Image = (Bitmap)e.Data.GetData(typeof(Bitmap));
        pb.Size = pictureBox1.Size;
        pb.Location = this.PointToClient(new Point(e.X - pb.Width / 2, e.Y - pb.Height / 2));
        this.Controls.Add(pb);
    }

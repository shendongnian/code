    private void FindOptimalRes(PictureBox picBox)
    {
        double h = Height / 4D; // or Height / 4.0
        double ratio = 4D / 3D; // or 4.0 / 3.0
        picBox.Size = new Size((int)(h * ratio), (int)h); // Size is now correct [133,100]
    }

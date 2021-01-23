    public void Populate(Color Color, PictureBox Stop)
    {
      Colour.BackColor = Color;             // Bottom left - PictureBox
      Hex.Text = ARGBToHex(Color.ToArgb()); // Hex (#703919) - TextBox
      Red.Text = Color.R.ToString();        // Red (153) - TextBox
      Green.Text = Color.G.ToString();      // Green (180) - TextBox
      Blue.Text = Color.B.ToString();       // Blue (209) - TextBox
      Alpha.Text = "100";                   // Alpha (100) - TextBox
  
      Stop.BackColor = Color;
    }

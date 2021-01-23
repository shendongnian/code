    private void PictureBoxesClick(object sender, EventArgs e)
    {
        if (sender is PictureBox)
		{
			MessageBox.Show("clicked on: " + ((PictureBox)sender).Name);
		}
    }
    

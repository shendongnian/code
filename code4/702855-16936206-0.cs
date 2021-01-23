    foreach (Control control in this.Controls)
    {
        if (control is PictureBox)
        {
            PictureBox pic = (PictureBox)control;
            pic.Image = Image.FromStream(stream); //something similar, this will only load the same image to every PictureBox
        }
    }

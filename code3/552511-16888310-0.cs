    Label ilabel = new Label(); // create a label
    Image i = Image.FromFile("image.png"); // read in image
    ilabel.Size = new Size(i.Width, i.Height); //set label to correct size
    ilabel.Image = i; // put image on label
    this.Controls.Add(ilabel); // add label to container (a form, for instance)

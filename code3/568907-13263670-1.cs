    var i = 0;
    foreach (var pbx in pbxCollection)
    {
        pbx.Image = imglst.Images[i++];
        //set location:
        pbx.Location = new Point(0, pbx.Image.Height * i);
        //add to form:
        this.Controls.Add(pbx);
    }

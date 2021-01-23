    private Image _origImage = new Bitmap(global::Project.Properties.Resources.driveChamber1);
    
    void DrawEllipse()
    {
        // Retrieve the image.
        Image bChamber = new Bitmap((Image)this._origImage.Clone());
    
        Graphics gChamber = Graphics.FromImage(bChamber);
    
        gChamber.FillEllipse(brushChamber, VirtualViewX(), VirtualViewY(), 10, 10);
        pictureBoxDriveView.Image = bChamber;
    }

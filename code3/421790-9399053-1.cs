    protected void UploadButton_Click( object sender, EventArgs e ) {
        if ( !ImageUpload.HasFile ) {
            return;
        }
        string imageBase64 = System.Convert.ToBase64String( ImageUpload.FileBytes );
        YourService service = new YourService();
        service.UploadImage( imageBase64 );

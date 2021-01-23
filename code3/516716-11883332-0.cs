    UIImage yourImage;
    //Download from your server here (I can fill it in if needed)
    UIImageView imageView = new UIImageView(new Frame(0, 0, 748, 759)); //This can also be setup in a XIB file
    imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
    imageView.Image = yourImage;

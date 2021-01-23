    Dictionary<string, Image> dict = new Dictionary<string, Image>();
    for (int i = 0; i <= 9; i++) {
    
        Image img = new Image();
        // suppose img.Name is an unique identifier then it is used as the images keys
        // in this dictionary. You create a direct unique mapping between the images name
        // and the image itself.
        dict.Add(img.Name, img);
    }
    // that's how you would use the unique image identifier to refer to an image
    Image img1 = dict["Image1"];
    Image img2 = dict["Image2"];
    Image img3 = dict["Image3"];

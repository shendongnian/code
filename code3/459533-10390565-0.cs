    // Class-level variable
    var _imageDictionary = new Dictionary<string,Image>();
    
    
    // Logic in method
    Image image;
    if(_imageDictionary.ContainsKey(textBox1.Text))
     image = _imageDictionary[textBox1.Text];
    else {
       image = // code to retrieve image from web
       _imageDictionary[textBox1.Text] = image;
    }
    
    // ... add it to your image list

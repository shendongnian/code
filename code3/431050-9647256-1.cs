    //a helper dictionary if you want to save the images and their names for later use
    var namesAndImages = new Dictionary<String, Image>();
    var resourcesSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);
            foreach (System.Collections.DictionaryEntry myResource in resourcesSet)
            {
                if (myResource.Value is Image) //is this resource is associated with an image
                {
                    String resName = myResource.Key.ToString(); //get resource's name
                    Image resImage = myResource.Value as Image; //get the Image itself
                    
                    namesAndImages.Add(resName, resImage);
                }
            }
            
            //now you can use the values saved in the dictionary and easily get their names
            ...

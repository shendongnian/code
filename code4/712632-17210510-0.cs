    Image newImage;        //Your image uploaded
    List<Image> listImages; //All the images from your DB (before insertion)
    foreach(Image img in listImages) {
       if(img['Priority'] < newImg['Priority']) 
       {
          SqlCommand cmd = new SqlCommand(
                      "UPDATE TestImage SET Priority=" + img['Priority'] - 1 + ";"); 
       }
       else
       {
          SqlCommand cmd = new SqlCommand(
                      "UPDATE TestImage SET Priority=" + img['Priority'] + 1 + ";"); 
       
       }
    }

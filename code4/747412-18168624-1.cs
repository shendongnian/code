    // Get the Date Created property 
    System.Drawing.Imaging.PropertyItem propertyItem = image.GetPropertyItem( 0x132 ); 
    if( propItem != null ) 
    { 
      // Extract the property value as a String. 
      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); 
      string text = encoding.GetString(propertyItem.Value, 0, propertyItem.Len - 1 ); 
    
      // Parse the date and time. 
      System.Globalization.CultureInfo provider = CultureInfo.InvariantCulture; 
      DateTime dateCreated = DateTime.ParseExact( text, "yyyy:MM:d H:m:s", provider ); 
    }

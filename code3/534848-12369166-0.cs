    string inputString = "11/08/2012";
    DateTime dt = DateTime.MinValue;
    try {
    dt = DateTime.Parse(inputString);    
    } 
    catch (Exception ex) {
    // handle the exception however you like.
    return;
    }
    string formattedDate = String.Format("{0:MMM d, yyyy}", dt);

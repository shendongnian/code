    String[] arr = new String[2];
    var mousePos = Mouse.GetPosition(imagePath);
    arr = mousePos.ToString().Split(',');
    double x = Double.Parse(arr[0].ToString());
    double y = Double.Parse(arr[1].ToString());

    var selItem = ((sender as ListBox).SelecteItem as MyItemType)
    //if Imgs property is a string is
    Image1.Source = new BitmapImage(new URI(selItem.Imgs, UriKind.RelativeOrAbsolute));
    //if Imgs property is a URI
    Image1.Source = new BitmapImage(selItem.Imgs);

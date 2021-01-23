    var img = @"/9j/4AAQSkZJRgABAQAAAQABAAD//gA7Q1JFQ ... "; // Full Base64 image as string here
    var imgBytes = Convert.FromBase64String(img);
    var ms = new InMemoryRandomAccessStream();
    var dw = new Windows.Storage.Streams.DataWriter(ms);
    dw.WriteBytes(imgBytes);
    await dw.StoreAsync();
    ms.Seek(0);
    
    var bm = new BitmapImage();
    bm.SetSource(ms);
    
    // img1 is an Image Control in XAML
    bm.ImageOpened += (s, e) => { this.img1.Source = bm; };
    bm.ImageFailed += (s, e) => { Debug.WriteLine(e.ErrorMessage); };

    String packText = String.Format("pack://application:,,,/{0};component/{1}",
        Assembly.GetEntryAssembly().FullName,
        "ImageDictionary.xaml");
    Uri imageUri = new Uri(packText);
    // or if you prefer:
    // Uri imageUri = new Uri("file:///.../ImageDictionary.xaml");
    //
    ImageSource source = GetImageSource(imageKey, imageUri);
    if (null != source)
    {
        this.Image.Source = source;
    }
    else
    {
        // bail ...
    }

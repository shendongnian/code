    foreach(string myFile in Directory.GetFiles( @"C:\ProgramData\MyApp" ) )
    {
    System.Windows.Controls.Image myLocalImage = new System.Windows.Controls.Image(); ;
    myLocalImage.Height = 200;
    myLocalImage.Margin = new Thickness( 5 );
    BitmapImage myImageSource = new BitmapImage();
    myImageSource.BeginInit();
    myImageSource.UriSource = new Uri( @"file:///" + myFile );
    myImageSource.EndInit();
    myLocalImage.Source = myImageSource;
    filePath.Add( myFile );
    ImageLog.Items.Add(myLocalImage);
    }

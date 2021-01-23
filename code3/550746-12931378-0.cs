     var _Path = @"Templates\SkyScrapper.xaml";
     var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
     var _File = await _Folder.GetFileAsync(_Path);
     var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);
     DependencyObject rootObject = XamlReader.Load(_ReadThis) as DependencyObject;
     var uc = (UserControl)rootObject;

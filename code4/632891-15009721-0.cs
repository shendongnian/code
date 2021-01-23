    var _Media = new Windows.UI.Xaml.Controls.MediaElement() { AutoPlay = false };
    var _Location = Windows.ApplicationModel.Package.Current.InstalledLocation;
    var _Folder = await _Location.GetFolderAsync("Assets");
    var _File = await _Folder.GetFileAsync("Ding.wav");
    var _Stream = await _File.OpenAsync(Windows.Storage.FileAccessMode.Read);
    _Media.SetSource(_Stream, _File.ContentType);
    _Media.Play();

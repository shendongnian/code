    using Microsoft.Xna.Framework.Media.PhoneExtensions;
    MediaLibrary m = new MediaLibrary();        
    for (int j = 0; j < m.Pictures.Count; j++)
    {
      var r = m.Pictures[j];
      MessageBox.Show(MediaLibraryExtensions.GetPath(r));
    }

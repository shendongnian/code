    using Microsoft.Xna.Framework.Media.PhoneExtensions;
    ...
    var picture = mediaLibrary.SavePicture(fileName, stream);
    shareMediaTask = new ShareMediaTask();
    shareMediaTask.FilePath = picture.GetPath();
    shareMediaTask.Show();

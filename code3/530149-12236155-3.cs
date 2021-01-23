    using System.IO;
    using System.Drawing.Image;
    public static Image ReadImageFromFile(string filename)
    {
        Image image = null;
        using(FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            image = Image.FromStream(stream);
        }
        return image;
    }

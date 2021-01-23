    using System.IO;
    using System.Linq;
    //...
    public class PictureInfo
    {
        public string Date { get; set; }
        public string Name { get; set; }
    }
    //...
    var directoryInfo = new DirectoryInfo(@"C:\folder");
    var pictureInfos = directoryInfo.GetFiles().Select(x => new PictureInfo
    {
        Date = x.Name.Substring(0, 8),
        Name = x.Name.Substring(8)
    }).ToArray();

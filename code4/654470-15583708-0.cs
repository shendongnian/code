    using System.IO;
    using System.Linq;
    //...
    var directoryInfo = new DirectoryInfo("<path>");
    var files = directoryInfo.GetFiles().Select(x => x.Name.Substring(0, 8)).ToArray();

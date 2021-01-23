       using System.Collections.Generic;
       using System.IO;
       using System.Linq;
       using Microsoft.Deployment.Compression;
       using Microsoft.Deployment.Compression.Zip;
     namespace <YourPackage>.Libs
     {
     public class ZipFile
     {
        private string _zipfilepath;
        public ZipFile(string zipfilepath)
        {
            _zipfilepath = zipfilepath;
        }
        public void Compress(string filePath,bool deleteSourceFolder)
        {
            var filePaths = new List<string>();
            if (Directory.Exists(filePath))
            {
                filePaths.AddRange(Directory.GetFileSystemEntries(filePath).ToList());
            }
            if (filePaths.Count > 0)
            {
                var zip = new ZipInfo(_zipfilepath);
                zip.Pack(filePath, true, CompressionLevel.None, null);
            }
            if(deleteSourceFolder)
                Directory.Delete(filePath,deleteSourceFolder);
        }
        public void Uncompress(string destinationPath)
        {
            var zip = new ZipInfo(_zipfilepath);
            zip.Unpack(destinationPath);
        }       
    }
}

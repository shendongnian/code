    using System.Security.AccessControl;
    using System.Security.Principal;
     var dir = System.Environment.ExpandEnvironmentVariables("%systemdrive%\\Program Files");
            
            if (!Directory.Exists(dir))
                {
                //System.IO.Directory.CreateDirectory(dir);
                string fileName = "file.txt";
                string sourcePath = @"C:/"; //@AppDomain.CurrentDomain.BaseDirectory;
                string targetPath = dir;
               
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(sourceFile, destFile, true);
            }

    // Variables:
    string folderPath = "";
    DirectoryInfo dirInfo = null;
    DirectorySecurity dirSec = null;
    int i - 0;
    
    try
    {
         // Read our Directory Path.
         do
         {
              Console.Write("Enter directory... ");
              folderPath = Console.ReadLine();
         }
         while (!Directory.Exists(folderPath));
    
         // Obtain our Access Control List (ACL)
         dirInfo = new DirectoryInfo(folderPath);
         dirSec = dirInfo.GetAccessControl();
    
         // Show the results.
         foreach (FileSystemAccessRule rule in dirSec.GetAccessRules(true, true, typeof(NTAccount)))
         {
              Console.WriteLIne("[{0}] - Rule {1} {2} access to {3}",
              i++,
              rule.AccessControlType == AccessControlType.Allow ? "grants" : "denies",
              rule.FileSystemRights,
              rule.IdentityReference.ToString());
          }
    }
    catch (Exception ex)
    {
         Console.Write("Exception: ");
         Console.WriteLIne(ex.Message);
    }
    
    Console.WriteLine(Environment.NewLine + "...");
    Console.Read();

    using System;
    using Limilabs.Client.IMAP;
    using System.Collections.Generic;
    
    namespace delete_gmail_trash
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (Imap imap = new Imap())
                {
                imap.ConnectSSL("imap.gmail.com");
                imap.UseBestLogin("username@gmail.com", "password for Gmail apps");
                // Recognize Trash folder
                List<FolderInfo> folders = imap.GetFolders();
    
                CommonFolders common = new CommonFolders(folders);
      
                FolderInfo trash = common.Trash;
                 // Find all emails we want to delete
                imap.Select(trash);
                List<long> uidList = imap.Search(Flag.All);
                foreach (long uid in uidList)
                {
                        imap.DeleteMessageByUID(uid);
                        Console.WriteLine("{0} deleted", uid);
                    }
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    imap.Close();
                }
    
            }
        }
    }

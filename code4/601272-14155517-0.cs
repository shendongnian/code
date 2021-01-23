    using System;
    using System.IO;
    using System.Text;
    using Redemption;
    
    namespace DumpPst
    {
        class Program
        {
            static void Main(string[] args)
            {
                // extract 'test.pst' in the 'test' folder
                ExtractPst("test.pst", Path.GetFullPath("test"));
            }
    
            public static void ExtractPst(string pstFilePath, string folderPath)
            {
                if (pstFilePath == null)
                    throw new ArgumentNullException("pstFilePath");
    
                RDOSession session = new RDOSession();
                RDOPstStore store = session.LogonPstStore(pstFilePath);
                ExtractPstFolder(store.RootFolder, folderPath);
            }
    
            public static void ExtractPstFolder(RDOFolder folder, string folderPath)
            {
                if (folder == null)
                    throw new ArgumentNullException("folder");
    
                if (folderPath == null)
                    throw new ArgumentNullException("folderPath");
    
                if (folder.FolderKind == rdoFolderKind.fkSearch)
                    return;
    
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
    
                foreach(RDOFolder child in folder.Folders)
                {
                    ExtractPstFolder(child, Path.Combine(folderPath, ToFileName(child.Name)));
                }
    
                foreach (var item in folder.Items)
                {
                    RDOMail mail = item as RDOMail;
                    if (mail == null)
                        continue;
    
                    mail.SaveAs(Path.Combine(folderPath, ToFileName(mail.Subject)) + ".eml", rdoSaveAsType.olRFC822);
                }
            }
    
            // converts any name into a plausible file name
            public static string ToFileName(string text)
            {
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentNullException("text");
    
                StringBuilder sb = new StringBuilder(text.Length);
                for (int i = 0; i < text.Length; i++)
                {
                    char c = text[i];
                    if ((c == '\\') ||
                        (c == '/') ||
                        (c == '*') ||
                        (c == '?') ||
                        (c == ':') ||
                        (c == '"') ||
                        (c == '<') ||
                        (c == '>') ||
                        (c == '|') ||
                        (c < 32))
                    {
                        sb.Append("_");
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                return sb.ToString();
            }
        }
    }

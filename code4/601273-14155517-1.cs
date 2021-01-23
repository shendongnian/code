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
    
          /// <summary>
          /// Converts a text into a valid file name.
          /// </summary>
          /// <param name="fileName">The file name.</param>
          /// <returns>
          /// A valid file name.
          /// </returns>
          public static string ToFileName(string fileName)
          {
              return ToFileName(fileName, null, null);
          }
          /// <summary>
          /// Converts a text into a valid file name.
          /// </summary>
          /// <param name="fileName">The file name.</param>
          /// <param name="reservedNameFormat">The reserved format to use for reserved names. If null '_{0}_' will be used.</param>
          /// <param name="reservedCharFormat">The reserved format to use for reserved characters. If null '_x{0}_' will be used.</param>
          /// <returns>
          /// A valid file name.
          /// </returns>
          public static string ToFileName(string fileName, string reservedNameFormat, string reservedCharFormat)
          {
              if (fileName == null)
                  throw new ArgumentNullException("fileName");
              if (string.IsNullOrEmpty(reservedNameFormat))
              {
                  reservedNameFormat = "_{0}_";
              }
              if (string.IsNullOrEmpty(reservedCharFormat))
              {
                  reservedCharFormat = "_x{0}_";
              }
              if (Array.IndexOf(ReservedFileNames, fileName.ToLowerInvariant()) >= 0 ||
                  IsAllDots(fileName))
                  return string.Format(reservedNameFormat, fileName);
              char[] invalid = Path.GetInvalidFileNameChars();
              StringBuilder sb = new StringBuilder(fileName.Length);
              foreach (char c in fileName)
              {
                  if (Array.IndexOf(invalid, c) >= 0)
                  {
                      sb.AppendFormat(reservedCharFormat, (short)c);
                  }
                  else
                  {
                      sb.Append(c);
                  }
              }
              string s = sb.ToString();
              // directory limit is 255
              if (s.Length > 254)
              {
                  s = s.Substring(0, 254);
              }
              if (string.Equals(s, fileName, StringComparison.Ordinal))
              {
                  s = fileName;
              }
              return s;
          }
          private static bool IsAllDots(string fileName)
          {
              foreach (char c in fileName)
              {
                  if (c != '.')
                      return false;
              }
              return true;
          }
          private static readonly string[] ReservedFileNames = new[]
          {
              "con", "prn", "aux", "nul",
              "com0", "com1", "com2", "com3", "com4", "com5", "com6", "com7", "com8", "com9",
              "lpt0", "lpt1", "lpt2", "lpt3", "lpt4", "lpt5", "lpt6", "lpt7", "lpt8", "lpt9"
          };
        }
    }

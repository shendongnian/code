    namespace Shortcut
    {
        using System;
        using System.Diagnostics;
        using System.IO;
        using Shell32;
        class Program
        {
            public static string GetShortcutTargetFile(string shortcutFilename)
            {
                string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
                string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);
                Shell shell = new Shell();
                Folder folder = shell.NameSpace(pathOnly);
                FolderItem folderItem = folder.ParseName(filenameOnly);
                if (folderItem != null)
                {
                    Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                    return link.Path;
                }
                return string.Empty;
            }
            static void Main(string[] args)
            {
                const string path = @"C:\link to foobar.lnk";
                Console.WriteLine(GetShortcutTargetFile(path));
            }
        }
    }

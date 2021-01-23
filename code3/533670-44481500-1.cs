    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    namespace DirLister
    {
	class Program
	{
		public static void Main(string[] args)
		{
            //with reflection I get the directory from where this program is running, thus listing all files from there and all subdirectories
			string[] st = FindFileDir(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
			using ( StreamWriter sw = new StreamWriter("listing.txt", false ) )
			{
				foreach(string s in st)
				{
                    //I write what I found in a text file
					sw.WriteLine(s);
				}
			}
		}
		private static string[] FindFileDir(string beginpath)
		{
			List<string> findlist = new List<string>();
            /* I begin a recursion, following the order:
		     * - Insert all the files in the current directory with the recursion
		     * - Insert all subdirectories in the list and rebegin the recursion from there until the end
		     */
			RecurseFind( beginpath, findlist );
			return findlist.ToArray();
		}
		private static void RecurseFind( string path, List<string> list )
		{
			string[] fl = Directory.GetFiles(path);
			string[] dl = Directory.GetDirectories(path);
			if ( fl.Length>0 || dl.Length>0 )
			{
                //I begin with the files, and store all of them in the list
				foreach(string s in fl)
					list.Add(s);
                //I then add the directory and recurse that directory, the process will repeat until there are no more files and directories to recurse
				foreach(string s in dl)
				{
					list.Add(s);
					RecurseFind(s, list);
				}
			}
		}
	}
    }

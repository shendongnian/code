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
			string[] st = FindFileDir(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
			using ( StreamWriter sw = new StreamWriter("listing.txt", false ) )
			{
				foreach(string s in st)
				{
					sw.WriteLine(s);
				}
			}
		}
		private static string[] FindFileDir(string beginpath)
		{
			List<string> findlist = new List<string>();
			RecurseFind( beginpath, findlist );
			return findlist.ToArray();
		}
		private static void RecurseFind( string path, List<string> list )
		{
			string[] fl = Directory.GetFiles(path);
			string[] dl = Directory.GetDirectories(path);
			if ( fl.Length>0 || dl.Length>0 )
			{
				foreach(string s in fl)
					list.Add(s);
				foreach(string s in dl)
				{
					list.Add(s);
					RecurseFind(s, list);
				}
			}
		}
	}
    }

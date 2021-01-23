	public static class BundleHelper
	{
		private static Dictionary<Bundle, List<string>> bundleIncludes = new Dictionary<Bundle, List<string>>();
		private static Dictionary<Bundle, List<string>> bundleFiles = new Dictionary<Bundle, List<string>>();
		private static void EnumerateFiles(Bundle bundle, string virtualPath)
		{
			if (bundleIncludes.ContainsKey(bundle))
				bundleIncludes[bundle].Add(virtualPath);
			else
				bundleIncludes.Add(bundle, new List<string> { virtualPath });
			int i = virtualPath.LastIndexOf('/');
			string path = HostingEnvironment.MapPath(virtualPath.Substring(0, i));
			if (Directory.Exists(path))
			{
				string fileName = virtualPath.Substring(i + 1);
				IEnumerable<string> fileList;
				if (fileName.Contains("{version}"))
				{
					var re = new Regex(fileName.Replace(".", @"\.").Replace("{version}", @"(\d+(?:\.\d+){1,3})"));
					fileName = fileName.Replace("{version}", "*");
					fileList = Directory.EnumerateFiles(path, fileName).Where(file => re.IsMatch(file));
				}
				else // fileName may contain '*'
					fileList = Directory.EnumerateFiles(path, fileName);
				if (bundleFiles.ContainsKey(bundle))
					bundleFiles[bundle].AddRange(fileList);
				else
					bundleFiles.Add(bundle, fileList.ToList());
			}
		}
		public static Bundle Add(this Bundle bundle, params string[] virtualPaths)
		{
			foreach (string virtualPath in virtualPaths)
				EnumerateFiles(bundle, virtualPath);
			return bundle.Include(virtualPaths);
		}
		public static Bundle Add(this Bundle bundle, string virtualPath, params IItemTransform[] transforms)
		{
			EnumerateFiles(bundle, virtualPath);
			return bundle.Include(virtualPath, transforms);
		}
		public static IEnumerable<string> EnumerateIncludes(this Bundle bundle)
		{
			return bundleIncludes[bundle];
		}
		public static IEnumerable<string> EnumerateFiles(this Bundle bundle)
		{
			return bundleFiles[bundle];
		}
	}

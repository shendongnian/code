        public static IHtmlString RenderStyleBundle(string bundlePath, string[] filePaths)
		{
			// Add a hash of the files onto the path to ensure that the filepaths have not changed.
			bundlePath = string.Format("{0}{1}", bundlePath, GetBundleHashForFiles(filePaths));
			var bundleIsRegistered = BundleTable
				.Bundles
				.GetRegisteredBundles()
				.Where(bundle => bundle.Path == bundlePath)
				.Any();
			if(!bundleIsRegistered)
			{
				var bundle = new StyleBundle(bundlePath);
				bundle.Include(filePaths);
				BundleTable.Bundles.Add(bundle);
			}
			return Styles.Render(bundlePath);
		}
		static string GetBundleHashForFiles(IEnumerable<string> filePaths)
		{
			// Create a unique hash for this set of files
			var aggregatedPaths = filePaths.Aggregate((pathString, next) => pathString + next);
			var Md5 = MD5.Create();
			var encodedPaths = Encoding.UTF8.GetBytes(aggregatedPaths);
			var hash = Md5.ComputeHash(encodedPaths);
			var bundlePath = hash.Aggregate(string.Empty, (hashString, next) => string.Format("{0}{1:x2}", hashString, next));
			return bundlePath;
		}

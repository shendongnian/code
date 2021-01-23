		void TestUrls ()
		{
			var path = Path.GetTempFileName ();
			Console.WriteLine ("TEST: {0} {1}", path, File.Exists (path));
			var array = new NSMutableArray ();
			var url = new NSUrl ("file://" + path);
			array.Add (url);
			var workspace = NSWorkspace.SharedWorkspace;
			workspace.DuplicateUrls (array, (urls, error) => {
				Console.WriteLine ("DUPLICATED: {0} {1}", urls, error);
				array.Add (urls.Values [0]);
				workspace.RecycleUrls (array, (urls2, error2) => {
					Console.WriteLine ("RECYCLED: {0} {1} {2}",
					                   urls2, error2, File.Exists (path));
				});
			});
		}

			/// <summary>
		/// Removes head.
		/// </summary>
		/// <param name="path">The path to drop head.</param>
		/// <param name="retainSeparator">If to retain separator before next folder when deleting head.</param>
		/// <returns>New path.</returns>
		public static string GetPathWithoutHead (string path, bool retainSeparator = false)
		{
			if (path == null) 
			{
				return path;
			}
			if (string.IsNullOrWhiteSpace (path)) 
			{
				 throw new ArgumentException(path, "The path is not of a legal form.");
			}
			var root = System.IO.Path.GetPathRoot (path);
			if (!string.IsNullOrEmpty(root) && !StartsWithAny(root,System.IO.Path.DirectorySeparatorChar,System.IO.Path.AltDirectorySeparatorChar))
			{				
				return path.Remove(0,root.Length);
			}
			var sep = path.IndexOf(System.IO.Path.DirectorySeparatorChar);
			var altSep = path.IndexOf(System.IO.Path.AltDirectorySeparatorChar);
			var pos = MaxPositiveOrMinusOne (sep, altSep);
			if (pos == -1)
			{
				return string.Empty;
			}
			if (pos == 0) 
			{
				return GetPathWithoutHead(path.Substring(pos+1), retainSeparator);
			}
			var eatSeparator = !retainSeparator ? 1 : 0;
			return path.Substring(pos+eatSeparator);
		}
		/// <summary>
		/// Startses the with.
		/// </summary>
		/// <returns><c>true</c>, if with was startsed, <c>false</c> otherwise.</returns>
		/// <param name="val">Value.</param>
		/// <param name="maxLength">Max length.</param>
		/// <param name="chars">Chars.</param>
		private static bool StartsWithAny(string value, params char[] chars)
		{
			foreach (var c in chars) 
			{
				if (value[0] == c) 
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Maxs the positive or minus one.
		/// </summary>
		/// <returns>The positive or minus one.</returns>
		/// <param name="val1">Val1.</param>
		/// <param name="val2">Val2.</param>
		private static int MaxPositiveOrMinusOne(int val1, int val2)
		{
			if (val1 < 0 && val2 < 0)
			{
				return -1;
			}
			return Math.Max(val1,val2: val2);
		}

    /// <summary>
		/// Gets an open stream on the specified embedded resource. It is the
		/// caller's responsibility to call Dispose() on the stream.
		/// The filename is of the format "folder.folder.filename.ext"
		/// and is case sensitive.
		/// </summary>
		/// <param name="assembly">The assembly from which to retrieve the Stream.</param>
		/// <param name="filename">Filename whose contents you want.</param>
		/// <returns>Stream object.</returns>
		public static Stream GetStream(Assembly assembly, string filename)
		{
			string name = String.Concat(assembly.GetName().Name, ".", filename);
			Stream s = assembly.GetManifestResourceStream(name);
			return s;
		}
		/// <summary>
		/// Get the contents of an embedded file as a string.
		/// The filename is of the format "folder.folder.filename.ext"
		/// and is case sensitive.
		/// </summary>
		/// <param name="assembly">The assembly from which to retrieve the file.</param>
		/// <param name="filename">Filename whose contents you want.</param>
		/// <returns>String object.</returns>
		public static string GetFileAsString(Assembly assembly, string filename)
		{
			using (Stream s = GetStream(assembly, filename))
			using (StreamReader sr = new StreamReader(s))
			{
				string fileContents = sr.ReadToEnd();
				return fileContents;
			}
		}

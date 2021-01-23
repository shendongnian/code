		/// <summary>
		/// Writes the file exclusively. No one could do anything with file while it writing
		/// </summary>
		/// <param name="path">Path.</param>
		/// <param name="data">Data.</param>
		public static void WaitFileAndWrite(string path, byte[] data)
		{
			while (true) {
				Stream fileStream = null;
				
				try {
					// FileShare.None is important: exclusive access during writing
					fileStream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
					fileStream.Write(data, 0, data.Length);
					break;
				} catch (IOException ex) {
					Console.WriteLine (ex);
					Thread.Sleep(10);
				} finally {
					if (fileStream != null) {
						fileStream.Close();
					}
				}
			}
		}
		/// <summary>
		/// Waits the file and read.
		/// </summary>
		/// <returns>The file and read.</returns>
		/// <param name="fileName">File name.</param>
		public static byte [] WaitFileAndRead(string fileName)
		{
			byte[] result = null;
			
			if (File.Exists(fileName)) {
				while (true) {
					Stream fileStream = null;
					
					try {
						fileStream = File.OpenRead(fileName);
						var length = fileStream.Length;
						result = new byte[length];
						fileStream.Read(result, 0, Convert.ToInt32(length));
						break;
					} catch (IOException ex) {
						Console.WriteLine (ex);
						Thread.Sleep(10);
					} finally {
						if (fileStream != null) {
							fileStream.Close();
						}
					}
				}
			}
			
			return result;
		}
	}

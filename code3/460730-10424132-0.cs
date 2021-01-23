			const int bufferSize = 4096;
			byte[] buffer = new byte[bufferSize];
			int fileSize = 1000 * 1024 * 1024;
			int total = 0;
			try
			{
				using (MemoryStream memory = new MemoryStream())
				{
					while (total < fileSize)
					{
						memory.Write(buffer, 0, bufferSize);
						total += bufferSize;
					}
				}
				MessageBox.Show("No errors"); 
			}
			catch (OutOfMemoryException)
			{
				MessageBox.Show("OutOfMemory around size : " + (total / (1024m * 1024.0m)) + "MB" ); 
			}

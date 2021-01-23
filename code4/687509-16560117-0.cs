			using (FileStream fsSource  = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				byte[] bytes = new byte[fsSource.Length];
				int numBytesToRead = (int)fsSource.Length;
			
				while (numBytesToRead > 0)
				{
					byte[] b = new byte[numBytesToRead];
					UTF8Encoding temp = new UTF8Encoding(true);
					while (fsSource.Read(b,0,b.Length) > 0)
					{
						Console.WriteLine(temp.GetString(b));
					}
				}
			}

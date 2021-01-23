		public static void Cleanup (string filename)
		{
			FileStream input = new FileStream(filename, FileMode.Open, FileAccess.Read);
			FileStream output = new FileStream(filename + ".tmp", FileMode.Create, FileAccess.Write);
			bool emptyLine = true;
			int c;
			while ((c = input.ReadByte()) != -1)
			{
				if (c == '\n')
				{
					if (!emptyLine)
					{
						output.WriteByte((byte)c);
						emptyLine = true;
					}
				}
				else
				{
					output.WriteByte((byte)c);
					emptyLine = false;
				}
			}
			input.Close();
			output.Close();
			File.Delete (filename);
			File.Copy(filename + ".tmp", filename);
			File.Delete(filename + ".tmp");
		}

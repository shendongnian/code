		public static void LogicalEraseLine(string filename, int toDel)
		{
			FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
			
			bool erasing = false;
			int c;
			
			while ((c = fs.ReadByte()) != -1)
			{
				if (fs.Position == toDel)
				{
					erasing = true;
				}
				else if (c == '\n')
				{
					erasing = false;
				}
				else if (erasing)
				{
					fs.Seek(-1, SeekOrigin.Current);
					fs.WriteByte((byte)'\n');
				}
			}
			
			fs.Close();
		}

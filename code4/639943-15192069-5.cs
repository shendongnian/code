		public static void LogicalEraseLine(string filename, int toDel)
		{
			FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
			fs.Seek(toDel, SeekOrigin.Current);
			int c;
			
			while ((c = fs.ReadByte()) != -1)
			{
				if (c == '\n')
				{
					break;
				}
				else
				{
					fs.Seek(-1, SeekOrigin.Current);
					fs.WriteByte((byte)'\n');
				}
			}
			
			fs.Close();
		}

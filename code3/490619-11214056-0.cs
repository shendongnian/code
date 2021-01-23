	private void DoTheJob()
	{
			[...]
			for (int i = 0; i < filebytes.Length; i++,counter++)
			{
				codedbytes.AddRange(BitConverter.GetBytes(Convert.ToChar((filebytes[i] * constbyte))));
				if (counter == blocksize)
				{
					using (FileStream tempwriter = File.Create(startdir + "\\temp" + index.ToString() + ".file"))
					{
						for (int x = 0; x < codedbytes.Count; x++)
						{
							tempwriter.WriteByte(codedbytes[x]);
						}				
					}
					codedbytes.Clear();
					counter = 0; tempindex.Add(index); index++;
				}
			}
			[...]
			for (int x = 0; x < tempindex.Count; x++)
			{
				codedbytes = new List<byte>(File.ReadAllBytes(startdir + "\\temp" + tempindex[x].ToString() + ".file"));
				[...]
			}
	}

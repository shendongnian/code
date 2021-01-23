    	static bool LargeAware(string file) {
			using (var fs = File.Open(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
				bool b = LargeAware(fs);
				fs.Close();
				return b;
			}
		}
		const int IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x20;
		static bool LargeAware(Stream stream) {
			var br = new BinaryReader(stream);
			var bw = new BinaryWriter(stream);
			if (br.ReadInt16() != 0x5A4D)       //No MZ Header
				return false;
			br.BaseStream.Position = 0x3C;
			var peloc = br.ReadInt32();         //Get the PE header location.
			br.BaseStream.Position = peloc;
			if (br.ReadInt32() != 0x4550)       //No PE header
				return false;
			br.BaseStream.Position += 0x12;
			long nFilePos = (int)br.BaseStream.Position;
			Int16 nLgaInt = br.ReadInt16();
			bool bIsLGA = (nLgaInt & IMAGE_FILE_LARGE_ADDRESS_AWARE) == IMAGE_FILE_LARGE_ADDRESS_AWARE;
			if (bIsLGA)
				return true;
			nLgaInt |= IMAGE_FILE_LARGE_ADDRESS_AWARE;
			long nFilePos1 = bw.Seek((int)nFilePos, SeekOrigin.Begin);
			bw.Write(nLgaInt);
			bw.Flush();
			long nFilePos2 = br.BaseStream.Seek(nFilePos, SeekOrigin.Begin);
			nLgaInt = br.ReadInt16();
			bIsLGA = (nLgaInt & IMAGE_FILE_LARGE_ADDRESS_AWARE) == IMAGE_FILE_LARGE_ADDRESS_AWARE;
			return bIsLGA;
		}

		// declare more of these appropriately laid
		// out structures for different pixel formats
		struct RGBA16
		{
			public uint R;
			public uint G;
			public uint B;
			public uint A;
		}
		struct RGBA8
		{
			public byte R;
			public byte G;
			public byte B;
			public byte A;
		}
		struct BRGA8
		{
			public byte B;
			public byte G;
			public byte R;
			public byte A;
		}
		...
		var handle = GCHandle.Alloc(tempBuffer /* the raw byte[] */, GCHandleType.Pinned);
		try
		{
			var ptr = handle.AddrOfPinnedObject();
			var safeBuffer = new SafeMemoryMappedViewHandle(true /* I believe DetachPixelData returns a copy? false otherwise  */)
			safeBuffer.SetHandle(ptr);
			
			#if STREAM_PROCESSING
				// pixel by pixel
				int offset = 0;
				for (int i = 0; i < width * height; i++)
				{
					var pixel = safeBuffer.Read<RGBA16>(offset);
					offset += RGB24bpp.Size;
				}
			#else
				// Read it all in at once - this makes a copy
				var pixels = new RGBA16[width * height];
				safeBuffer.ReadArray<RGBA16>(0, pixels, 0, width * height);
			#endif
		}
		finally
		{
			safeBuffer.Dispose();
			handle.Free;
		}

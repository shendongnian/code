			byte[] rawData = new byte[1024];
			GCHandle rawDataHandle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
			int* iPtr = (int*)rawDataHandle.AddrOfPinnedObject().ToPointer();
			int length = rawData.Length / sizeof (int);
			for (int idx = 0; idx < length; idx++, iPtr++)
			{
				(*iPtr) = idx;
				Console.WriteLine("Value of integer at pointer position: {0}", (*iPtr));
			}
			rawDataHandle.Free();

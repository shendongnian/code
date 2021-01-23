	const int FLOAT_SIZE = 4;
	byte[] baSource = new byte[FLOAT_SIZE];
	float[] faDest = new float[1];
	baSource[0] = 0xA7;
	baSource[1] = 0x68;
	baSource[2] = 0xB9;
	baSource[3] = 0x44;
	var gch = GCHandle.Alloc(baSource, GCHandleType.Pinned);
	try
	{
		var source = gch.AddrOfPinnedObject();
		Marshal.Copy(source, faDest, 0, 1);
	}
	finally
	{
		gch.Free();
	}

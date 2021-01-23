    public static void WriteImage(ref SqlCommand CMD, Bitmap Img, string ParaName)
    {
    	WriteImage(ref CMD, Img, ParaName, SupportedImageFormats.JPG);
    }
    public static void WriteImage(ref SqlCommand CMD, Bitmap Img, string ParaName, SupportedImageFormats imgFormat)
    {
    	using (System.IO.MemoryStream MS = new System.IO.MemoryStream()) {
    		SaveToStream(MS, Img, imgFormat, false);
    		CMD.Parameters.Add(ParaName, SqlDbType.VarBinary).Value = MS.GetBuffer();
    	}
    }

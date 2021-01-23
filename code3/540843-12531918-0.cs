	for (int i = 0; i < Globls.iterationCount; i++)
	{
		if (bw_Obj.CancellationPending)
		{
			eve.Cancel = true;
			break;
		}
		byte[] rawData4 = DMM4.IO.Read(4 * numReadings);
		TempDisplayData_DMM4.Add(rawData4);
		lock (Globls.Display_DataDMM4.SyncRoot)
		{
		Globls.Write_DataDMM4 = ArrayList.Synchronized(TempDisplayData_DMM4);
		}
	}

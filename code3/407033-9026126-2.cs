    		const int BUFFER_SIZE=4096;
		byte[] typeData = new byte[BUFFER_SIZE];
		int iMaxData = ioStream.Read(typeData, 0, BUFFER_SIZE);
	 	GCHandle objHandle = new GCHandle();
		iMaxData = ioStream.Read(typeData, 0, BUFFER_SIZE); //read the stream
		try
                {
                        
                   objHandle = GCHandle.Alloc(typeData, GCHandleType.Pinned);
                   objData = (RM_CLIENT_DATA)Marshal.PtrToStructure(objHandle.
                               AddrOfPinnedObject(),typeof(RM_CLIENT_DATA));
                }
                catch (Exception ex)
                {
                    ErrorCode = -6;
                    ErrorMessage = string.Format("ReadMessageToGenericStruct: Error: {0} 
                         attempting to move data into RM_CLIENT_DATA struct.", ex.Message);
                    return bResult;
                }
                finally
                {
                    objHandle.Free();
                }

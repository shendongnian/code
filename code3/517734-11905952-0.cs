	// First receive the size
	var sizeBytes = new byte[4];
	clientSocket.Receive(sizeBytes, 4, 0);
	var size = BitConverter.ToInt32(sizeBytes, 0);
	// Then receive the data
	byte[] fileData = new byte[size];
	byte[] clientData = new byte[8192];
	int totalBytes = 0;
	while (totalBytes < size)
	{
		// This may return anything between 0 and 8192. Check for 0, since that's when the client disconnects.
		int bytesReceived = clientSocket.Receive(clientData);
		
		// You now have received a chunk of data of bytesReceived length. Append it into the fileData array.
		Buffer.BlockCopy(clientData, 0, fileData, totalBytes, bytesReceived);
		
		totalBytes += bytesReceived;
	}

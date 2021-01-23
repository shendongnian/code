	class Program
	{
		private const int SIZE_OF_BUFFER = 1024 * 16;
		private const string FILE_PATH_ORIGINAL = @"C:\test.xlsx",
							FILE_PATH_WithId = @"C:\test1.xlsx",
							FILE_PATH_IdRemoved = @"C:\test2.xlsx";
		private static readonly byte[] idbyte = UnicodeEncoding.Default.GetBytes("b669fd8c904d48e0945c16cac1dc5ed9");
		static void Main(string[] args)
		{
			AddGuidToFile(FILE_PATH_ORIGINAL, FILE_PATH_WithId);
			RemoveGuidToFile(FILE_PATH_WithId, FILE_PATH_IdRemoved);
			CompairFiles(FILE_PATH_ORIGINAL, FILE_PATH_IdRemoved);
			Console.ReadLine();
		}
		private static void AddGuidToFile(string sourceFilePath, string destinationFilePath)
		{
			byte[] buffer = new byte[SIZE_OF_BUFFER];
			FileStream input = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read),
						output = new FileStream(destinationFilePath, FileMode.OpenOrCreate, FileAccess.Write);
			int read;
			try
			{
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)	//Copy source file to destination file.
				{
					output.Write(buffer, 0, read);
				}
				output.Write(idbyte, 0, idbyte.Length);						//Add guid to the end of the destination file.
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				//Close files
				input.Close();
				output.Close();
			}
		}
		private static void RemoveGuidToFile(string sourceFilePath, string destinationFilePath)
		{
			byte[] currentBuffer = new byte[SIZE_OF_BUFFER],
					nextBuffer = new byte[SIZE_OF_BUFFER],
					tempBuffer;
			FileStream input = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read),
						output = new FileStream(destinationFilePath, FileMode.OpenOrCreate, FileAccess.Write);
			int currentRead,
				nextRead = 0;										//Initialize to 0 incase file's lenght is less then SizeOfBuffer.
			try
			{
				currentRead = input.Read(currentBuffer, 0, currentBuffer.Length);	//Get first chunk.
				if (currentRead == currentBuffer.Length)							//If first chunck is a full buffer then loop until it is not.
				{
					nextRead = input.Read(nextBuffer, 0, nextBuffer.Length);
					while (nextRead > idbyte.Length)
					{
						output.Write(currentBuffer, 0, currentRead);				//Since nextBuffer is large enough to contain the ID, write the current buffer out.
						//Swap buffers.
						tempBuffer = currentBuffer;
						currentBuffer = nextBuffer;
						nextBuffer = tempBuffer;
						//Update counts and fill next buffer.
						currentRead = nextRead;
						nextRead = input.Read(nextBuffer, 0, nextBuffer.Length);
					}
				}
				currentRead += nextRead - idbyte.Length;							//Update currentRead to be the number of bytes in the buffer which are not part of the ID.
				output.Write(currentBuffer, 0, currentRead);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				//Close files
				input.Close();
				output.Close();
			}
		}
		private static void CompairFiles(string originalFilePath, string idRemovedFilePath)
		{
			byte[] originalBuffer = new byte[SIZE_OF_BUFFER],
					idRemovedBuffer = new byte[SIZE_OF_BUFFER];
			FileStream original = new FileStream(originalFilePath, FileMode.Open, FileAccess.Read),
						idRemoved = new FileStream(idRemovedFilePath, FileMode.Open, FileAccess.Read);
			int originalRead,
				idRemovedRead;
			try
			{
				do
				{
					originalRead = original.Read(originalBuffer, 0, originalBuffer.Length);
					idRemovedRead = idRemoved.Read(idRemovedBuffer, 0, idRemovedBuffer.Length);
					if (originalRead != idRemovedRead) { throw new Exception("Error: file sizes do not match.  originalRead = " + originalRead + ", idRemovedRead = " + idRemovedRead + ", SIZE_OF_BUFFER = " + SIZE_OF_BUFFER); }
					for (int i = 0; i < originalRead; i++)
					{
						if (originalBuffer[i] != idRemovedBuffer[i]) { throw new Exception("Error: file contents do not match.  i = " + i + ",inputBuffer[i] = " + originalBuffer[i] + ", idRemovedBuffer[i] = " + idRemovedBuffer[i]); }
					}
				}
				while (originalRead == idRemovedRead && originalRead > 0);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				//Close files
				original.Close();
				idRemoved.Close();
			}
		}
	}

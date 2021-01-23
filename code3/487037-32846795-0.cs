    //var ticks = **some_array_you_want_to_write_as_csv**
    using (var memoryStream = new System.IO.MemoryStream())
				{
					using (var textWriter = new System.IO.StreamWriter(memoryStream))
					{
						using (var csv = new CsvHelper.CsvWriter(textWriter))
						{
							csv.Configuration.DetectColumnCountChanges = true; //error checking
							csv.Configuration.RegisterClassMap<TickDataClassMap>();
							csv.WriteRecords(ticks);
							textWriter.Flush();
							//write to disk
							using (var fileStream = new System.IO.FileStream(targetFileName, System.IO.FileMode.Create))
							{
								memoryStream.Position = 0;
								memoryStream.CopyTo(fileStream);
								
							}
							//write sha256 hash, ensuring that the file was properly written
							using (var sha256 = System.Security.Cryptography.SHA256.Create())
							{
								memoryStream.Position = 0;
								var hash = sha256.ComputeHash(memoryStream);
								using (var reader = System.IO.File.OpenRead(targetFileName))
								{
									System.IO.File.WriteAllText(targetFileName + ".sha256", hash.ConvertByteArrayToHexString());
								}
							}
						}
					}
				}

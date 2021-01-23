		private static void AppendTransaction(Transaction transaction)
		{
			const string filename = "transactions.json";
			bool firstTransaction = !File.Exists(filename);
			JsonSerializer ser = new JsonSerializer();
			ser.Formatting = Formatting.Indented;
			ser.TypeNameHandling = TypeNameHandling.Auto;
			using (var fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
			{
			    Encoding enc = firstTransaction ? new UTF8Encoding(true) : new UTF8Encoding(false);
			    using (var sw = new StreamWriter(fs, enc))
				using (var jtw = new JsonTextWriter(sw))
				{
					if (firstTransaction)
					{
						sw.Write("[");
                        sw.Flush();
					}
					else
					{
						fs.Seek(-Encoding.UTF8.GetByteCount("]"), SeekOrigin.End);
                        sw.Write(",");
                        sw.Flush();
					}
					ser.Serialize(jtw, transaction);
					sw.Write(']');
				}
			}
		}

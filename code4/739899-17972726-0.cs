           while (true) {
				Console.WriteLine("Waiting for a connection...");
				// Program is suspended while waiting for an incoming                      connection.
				Socket handler = listener.Accept();
				data = null;
				// An incoming connection needs to be processed.
				while (true) {
					bytes = new byte[1024];
					int bytesRec = handler.Receive(bytes);
					data += Encoding.ASCII.GetString(bytes,0,bytesRec);
					if (data.IndexOf("<EOF>") > -1) {
						break;
					}
				}
				// Show the data on the console.
				Console.WriteLine( "Text received : {0}", data);
				// Echo the data back to the client.
				byte[] msg = Encoding.ASCII.GetBytes(data);
				handler.Send(msg);
				handler.Shutdown(SocketShutdown.Both);
				handler.Close();
			}

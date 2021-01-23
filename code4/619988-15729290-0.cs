		static void p_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			var p = (PortaCOM)sender;
			try
			{
			   **var b = new List<byte>(); 
				while (p.BytesToRead > 0) 
					b.Add((byte)p.ReadByte()); 
				if (b.IsEmpty()) 
					return;**
				var retorno = Encoding.ASCII.GetString(b.ToArray());
				Console.WriteLine(retorno);
			}
			catch (Exception err) { Console.WriteLine(err.Message); }
		}

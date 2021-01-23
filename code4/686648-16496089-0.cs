		CountdownEvent countdownEvent;
		
		public string devicesPlus()
		{
			psi.Arguments = "start-server";
			countdownEvent = new CountdownEvent(2);
			call = Process.Start(psi);
			call.OutputDataReceived += new DataReceivedEventHandler(call_OutputDataReceived);
			call.ErrorDataReceived += new DataReceivedEventHandler(call_OutputDataReceived);
			call.EnableRaisingEvents = true;
			call.Exited += new EventHandler(call_Exited);
			call.Start();
			call.BeginOutputReadLine();
			call.BeginErrorReadLine();
			call.StandardInput.Close();
			call.WaitForExit();
			countdownEvent.Wait();
			return outData.ToString();
		}
		private void call_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (e.Data != null)
			{
				// prevent race condition when data is received form stdout and stderr at the same time
				lock (outData)
				{
					outData.Append(e.Data);
				}
			}
			else
			{
				// end of stream
				countdownEvent.AddCount();
			}
		}

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.IO.Ports;
	namespace Sample
	{
		public class SocketWrapper
		{
			#region Static Variables
			private static AutoResetEvent _SendWaitHandle = new AutoResetEvent(false);
			#endregion
			#region Member Variables
			private object _SendLockToken = new object();
			#endregion
			#region Public Methods
			public void Write(byte[] data)
			{
				Monitor.Enter(_SendLockToken);
				try
				{
					// Reset Handle
					_SendWaitHandle.Reset();
					// Send Data
					// Your Logic
					// Wait for ACK
					if (_SendWaitHandle.WaitOne(1000)) // Will wait for 1000 miliseconds
					{
						// ACK Received
						// Send EOT
					}
					else
					{
						// Timeout Occurred
						// Your Logic To Handle Timeout
					}
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					Monitor.Exit(_SendLockToken);
				}
			}
			#endregion
			#region Private Methods
			private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
			{
				// When ACK is received call SET
				_SendWaitHandle.Set();
			}
			#endregion
		}
	}

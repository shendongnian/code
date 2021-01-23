    private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    	serialPort.Encoding = ASCIIEncoding.UTF8;
    	string ser_data = serialPort.ReadLine();
    	txtAck.Invoke(new UpdateTextCallback(this.UpdateTextAck), new object[] { ser_data });
    
    	string[] str = ser_data.Split(new char[] { '$' }, 2);
    	if (str.Length > 1)
    	{
    		for (int i = 1; i < str.Length; i++)
    		{
    			string temp1 = str[i];
    			if (temp1.StartsWith("GPGGA"))
    			{
    				StreamWriter objWriter = new StreamWriter(@"D:\Server.txt", true);
    				try
    				{
    					string[] temp2 = temp1.Split(',');
    					if (temp2.Length > 1)
    					{
    						string Time_GPS = temp2[1];
    						txtEasting.Invoke(new UpdateTextCallback(this.UpdateTextEast), new object[] { Time_GPS });
    						string text = "Time : " + Time_GPS;
    						// StreamWriter objWriter = new System.IO.StreamWriter(@"D:\Server.txt", true);
    						objWriter.WriteLine(text);
    					}
    					if (temp2.Length > 2)
    					{
    						string Lat = temp2[2];
    						txtLatitude.Invoke(new UpdateTextCallback(this.UpdateTextLat), new object[] { Lat });
    						string text = " Latitude : " + Lat;
    						// StreamWriter objWriter = new System.IO.StreamWriter(@"D:\Server.txt", true);
    						objWriter.WriteLine(text);
    					}
    					if (temp2.Length > 4)
    					{
    						string Long = temp2[4];
    						txtLongitude.Invoke(new UpdateTextCallback(this.UpdateTextLong), new object[] { Long });
    						string text = " Longitude : " + Long;
    						// StreamWriter objWriter = new System.IO.StreamWriter(@"D:\Server.txt", true);
    						objWriter.WriteLine(text);
    					}
    					if (temp2.Length > 9)
    					{
    						string Alt = temp2[9];
    						txtNorthing.Invoke(new UpdateTextCallback(this.UpdateTextNorth), new object[] { Alt });
    						string text = " Altitude : " + Alt;
    						// StreamWriter objWriter = new System.IO.StreamWriter(@"D:\Server.txt", true);
    						objWriter.WriteLine(text);
    					}
    					objWriter.WriteLine(".\n");
    				}
    				finally
    				{
    					objWriter.Close();
    				}
    				
    				flag_status = 0;
    			}
    		}
    	}
    }

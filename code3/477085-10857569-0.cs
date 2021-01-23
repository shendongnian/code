    NetworkUnion union = (NetworkUnion)ar.AsyncState;
                union.BytesRead += tcpStream.EndRead(ar);
                if (union.BytesRead < union.TargetSize)
                    tcpStream.BeginRead(union.ByteArray, union.BytesRead, union.TargetSize - union.BytesRead, new AsyncCallback(ReadCommandCallback), union);
                else
                {
                    NetworkUnion payload = new NetworkUnion();
                    NetworkPacket pkt = (NetworkPacket)union.getArrayAsStruct();
                    // Respond to the packet
                    // Read the payload
                    payload.ByteArray = new byte[pkt.payloadSize];
                    tcpStream.Read(payload.ByteArray, 0, pkt.payloadSize);
                    // Determine what the payload is!
					double yourvalue = new double(); 
                    switch (pkt.code)
                    {
                        case (int)PacketCode.STATE:
                            payload.ObjectType = typeof(NetworkState);
                            NetworkState state = (NetworkState)payload.getArrayAsStruct();
                            yourvalue = Convert.ToDouble(state.mainFuel);
                            break;
				/**
					Other Cases....
				
				*/
			 // After the switch 
	
						Handle.fuelGauge.Dispatcher.Invoke(
                                System.Windows.Threading.DispatcherPriority.Normal,
                                new Action(
                                    delegate()
                                    {
                                        Handle.fuelGauge.Value = yourvalue;
                                    }
                            ));	
							
							

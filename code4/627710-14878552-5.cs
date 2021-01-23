    static void TestRtspClient()
            {
    
                Console.WriteLine("Test #1. Press a key to continue. Press Q to Skip");
                if (Console.ReadKey().Key != ConsoleKey.Q)
                {
    
                    //Make a client
                    //This host uses Udp but also supports Tcp if Nat fails
                    Rtsp.RtspClient client = new Rtsp.RtspClient("rtsp://178.218.212.102:1935/live/Stream1");
                StartTest:
                    //Assign some events (Could log each packet to a dump here)
                    client.OnConnect += (sender, args) => { Console.WriteLine("Connected to :" + client.Location); };
                    client.OnRequest += (sender, request) => { Console.WriteLine("Client Requested :" + request.Location + " " + request.Method); };
                    client.OnResponse += (sender, request, response) => { Console.WriteLine("Client got response :" + response.StatusCode + ", for request: " + request.Location + " " + request.Method); };
                    client.OnPlay += (sender, args) =>
                    {
                        //Indicate if LivePlay
                        if (client.LivePlay)
                        {
                            Console.WriteLine("Playing from Live Source");
                        }
    
                        //Indicate if StartTime is found
                        if (client.StartTime.HasValue)
                        {
                            Console.WriteLine("Media Start Time:" + client.StartTime);
    
                        }
    
                        //Indicate if EndTime is found
                        if (client.EndTime.HasValue)
                        {
                            Console.WriteLine("Media End Time:" + client.EndTime);
                        }
                    };
                    client.OnDisconnect += (sender, args) => { Console.WriteLine("Disconnected from :" + client.Location); };
    
                    try
                    {
                        //Try to StartListening
                        client.StartListening();
                    }
                    catch (Exception ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Was unable to StartListening: " + ex.Message);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
    
                    //If We are connected
                    if (client.Connected && client.Client != null)
                    {
    
                        //Add some more events once Listening
                        client.Client.RtpPacketReceieved += (sender, rtpPacket) => { Console.WriteLine("Got a RTP packet, SequenceNo = " + rtpPacket.SequenceNumber + " Channel = " + rtpPacket.Channel + " PayloadType = " + rtpPacket.PayloadType + " Length = " + rtpPacket.Length); };
                        client.Client.RtpFrameChanged += (sender, rtpFrame) => { Console.BackgroundColor = ConsoleColor.Blue; Console.WriteLine("Got a RTPFrame PacketCount = " + rtpFrame.Count + " Complete = " + rtpFrame.Complete); Console.BackgroundColor = ConsoleColor.Black; };
                        client.Client.RtcpPacketReceieved += (sender, rtcpPacket) => { Console.WriteLine("Got a RTCP packet Channel= " + rtcpPacket.Channel + " Type=" + rtcpPacket.PacketType + " Length=" + rtcpPacket.Length + " Bytes = " + BitConverter.ToString(rtcpPacket.Payload)); };
                        client.Client.RtcpPacketReceieved += (sender, rtcpPacket) => { Console.BackgroundColor = ConsoleColor.Green; Console.WriteLine("Sent a RTCP packet Channel= " + rtcpPacket.Channel + " Type=" + rtcpPacket.PacketType + " Length=" + rtcpPacket.Length + " Bytes = " + BitConverter.ToString(rtcpPacket.Payload)); Console.BackgroundColor = ConsoleColor.Black; };
    
                        Console.WriteLine("Waiting for packets... Press Q to exit");
    
                        //Ensure we recieve a bunch of packets before we say the test is good
                        while (Console.ReadKey().Key != ConsoleKey.Q) { }
    
                        try
                        {
                            //Send a few requests just because
                            var one = client.SendOptions();
                            var two = client.SendOptions();
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine("Sending Options Success");
                            Console.WriteLine(string.Join(" ", one.GetHeaders()));
                            Console.WriteLine(string.Join(" ", two.GetHeaders()));
                            Console.BackgroundColor = ConsoleColor.Black;
    
                            //Print information before disconnecting
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine("RtcpBytes Sent: " + client.Client.TotalRtcpBytesSent);
                            Console.WriteLine("Rtcp Packets Sent: " + client.Client.TotalRtcpPacketsSent);
                            Console.WriteLine("RtcpBytes Recieved: " + client.Client.TotalRtcpBytesReceieved);
                            Console.WriteLine("Rtcp Packets Recieved: " + client.Client.TotalRtcpPacketsReceieved);
                            Console.WriteLine("Rtp Packets Recieved: " + client.Client.TotalRtpPacketsReceieved);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sending Options Failed");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
    
                        //All done with the client
                        client.StopListening();
                    }
    
                    //All done
                    Console.WriteLine("Exiting RtspClient Test");
    
                    //Perform another test if we need to
                    if (client.Location.ToString() != "rtsp://fms.zulu.mk/zulu/a2_1")
                    {
                        //Do another test
                        Console.WriteLine("Press a Key to Start Test #2 (Q to Skip)");
                        if (System.Console.ReadKey().Key != ConsoleKey.Q)
                        {
    
                            //Try another host (this one uses Tcp and forces the client to switch from Udp because Udp packets usually never arrive)
                            //We will not specify Tcp we will allow the client to switch over automatically
                            client = new Rtsp.RtspClient("rtsp://fms.zulu.mk/zulu/a2_1");
                            //Switch in 5 seconds rather than the default of 10
                            client.ProtocolSwitchSeconds = 5;
                            Console.WriteLine("Performing 2nd Client test");
                            goto StartTest;
                        }
                    }
                    
                }
            }

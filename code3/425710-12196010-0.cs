                //Decides if packet to be sent in a go or divide in small chunks
                objPingOptn.DontFragment = true;
                //Creating a buffer of 32 bytes.
                string tPacketData = "DummyPacketsDataDummyPacketsData";
                byte[] bBuffer = Encoding.ASCII.GetBytes(tPacketData);
                //Can provide host name directly if available
                System.Net.NetworkInformation.PingReply objPingRply = objPing.Send(objURL.Host, 120, bBuffer, objPingOptn);
                objPing.Dispose();
                if (objPingRply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    return true;
                else
                    return false;

               int rbytes = client.EndReceive(ar);
                if (rbytes > state.buffer)
                {
                    byte[] bytesReceived = new byte[rbytes];
                    Buffer.BlockCopy(state.buffer, 0, bytesReceived, 0, rbytes);
                    state.myQueue.Enqueue(bytesReceived);                
						client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback_onQuery), state)
                }

                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    // it's not a "response" unless it's terminated with "<EOF>" right?
                    response = state.sb.ToString();
                    if (response.IndexOf("<EOF>") != -1)
                    {
                        state.sb.Clear();
                        receiveDone.Set();
                    }
                    else
                    {
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                }
                else
                {
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString(); // this is a partial response, not terminated with "<EOF>"
                    }
                    receiveDone.Set();
                }

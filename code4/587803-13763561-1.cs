    if (bytesRead > 0)
        {
            // There might be more data, so store the data received so far.
            memoryStream.Write(state.buffer, 0, bytesRead);
            // Get the rest of the data.
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReceiveCallback_onQuery), state);
        }
    else
    {
        // All the data has arrived; put it in response.
        response_onQueryHistory = ByteArrayToObject(memoryStream.ToArray());
        // Signal that all bytes have been received.
        receiveDoneQuery.Set();
    }

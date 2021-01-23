    private void EndRead(IAsyncResult ar)
    {
        var state = ar.AsyncState as State;
        var bytesRead = state.Stream.EndRead(ar);
        if (bytesRead > 0)
        {
            string value = Encoding.UTF8.GetString(state.Buffer, 0, bytesRead);
            // TODO: do something with the value being read
            // Warning: if this is a desktop application such as WinForms
            // and you need to update some control on the GUI make sure that 
            // you marshal the call on the main UI thread, because this EndRead
            // method will be invoked on a thread drawn from the thread pool.
            // In WinForms you need to use Control.Invoke or Control.BeginInvoke
            // method to marshal the call on the UI thread.
            state.Stream.BeginRead(state.Buffer, 0, state.Buffer.Length, EndRead, state);
        }
        else
        {
            // finished reading => dispose the FileStream
            state.Stream.Dispose();
        }
    }

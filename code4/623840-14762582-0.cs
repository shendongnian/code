    public static Task<byte[]> ReceiveAsync(this UdpClient client, IPEndPoint endpoint)
    {
    	TaskCompletionSource<byte[]> tcs = new TaskCompletionSource<byte[]>();
    	AsyncCallback callback = ar => {
    		try
    		{
    			byte[] bytes = client.EndReceive(ar, ref endpoint);
    			tcs.SetResult(bytes);
    		}
    		catch(Exception ex)
    		{
    			tcs.SetException(ex);
    		}
    	};
    	client.BeginReceive(callback, null);
    	return tcs.Task;
    }

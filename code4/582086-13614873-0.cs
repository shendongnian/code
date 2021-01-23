    public static Task<List<Usernames>> my_function()
    {
        var tcs = new TaskCompletionSource<List<Usernames>>();
        PostClient conn = new PostClient(POST);
        conn.DownloadStringCompleted += (object sender2, DownloadStringCompletedEventArgs z) =>
        {
            if (z.Error == null)
            {
                //Process result
                string data = z.Result;
                //MessageBox.Show(z.Result);  
    
                //Convert Login value to true false
                try
                {
                    ///... do stuff here
    
                    tcs.SetResult(null);
                }
                finally
                {
                }
            }
            else
            {
                tcs.SetException(new Exception());//todo put in real exception
            }
        };
    
        return tcs.Task;
    }

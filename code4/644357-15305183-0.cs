    public WebClient MyFunctionName()
    {
            #region Baixando as imagens e as exibindo
            WebClient client = new WebClient ();
            client.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) => {
                byte[] result = e.Result;
                if (result != null) {
                    NSData data1 = NSData.FromArray (e.Result);
                    UIImage img = UIImage.LoadFromData (data1);
                    InvokeOnMainThread (delegate {
                        avatar.Image = img;
    
    
                    });
    
                }
            };
            client.DownloadDataAsync (new Uri ("http://xx.xx.xx.xx/fbcache/"+list [indexPath.Row].comentario_id_usuario+".jpg"));
            #endregion
            return client;
    }

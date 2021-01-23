              FtpWebRequest request = null;
            request.Timeout = 3000;
            Func<WebResponse> responseDelegate = () => request.GetResponse();
            var asynchRes = responseDelegate.BeginInvoke(null, null);
            try
            {
                responseDelegate.EndInvoke(asynchRes);
            }
            catch (TimeoutException e)
            { 
                // bla
            }

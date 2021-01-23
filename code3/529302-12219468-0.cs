            (from strm in twitterCtx.UserStream
             where strm.Type == UserStreamType.User
             select strm)
            .StreamingCallback(strm =>
            {
                if (strm.Status == TwitterErrorStatus.RequestProcessingException)
                {
                    WebException wex = strm.Error as WebException;
                    if (wex != null && wex.Status == WebExceptionStatus.ConnectFailure)
                    {
                        Console.WriteLine(wex.Message + " You might want to reconnect.");
                    }
                    Console.WriteLine(strm.Error.ToString());
                    return;
                }
                Console.WriteLine(strm.Content + "\n");
                if (count++ >= 25)
                {
                    strm.CloseStream();
                }
            })
            .SingleOrDefault();

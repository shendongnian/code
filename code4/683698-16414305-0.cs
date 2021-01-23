        public static void CopyToStreamAsync(this Stream source, Stream destination,
            Action<Stream, Stream, Exception> completed, Action<uint> progress,
            uint bufferSize, uint? maximumDownloadSize, TimeSpan? timeout)
        {
            byte[] buffer = new byte[bufferSize];
            Action<Exception> done = exception =>
                {
                    if (completed != null)
                    {
                        completed(source, destination, exception);
                    }
                };
            int maxDownloadSize = maximumDownloadSize.HasValue
                ? (int)maximumDownloadSize.Value
                : int.MaxValue;
            int bytesDownloaded = 0;
            IAsyncResult asyncResult = source.BeginRead(buffer, 0, new[] { maxDownloadSize, buffer.Length }.Min(), null, null);
            Action<IAsyncResult, bool> endRead = null;
            endRead = (innerAsyncResult, innerIsTimedOut) =>
                {
                    try
                    {
                        int bytesRead = source.EndRead(innerAsyncResult);
                        if (innerIsTimedOut)
                        {
                            done(new TimeoutException());
                        }
                        int bytesToWrite = new[] { maxDownloadSize - bytesDownloaded, buffer.Length, bytesRead }.Min();
                        destination.Write(buffer, 0, bytesToWrite);
                        bytesDownloaded += bytesToWrite;
                        if (!progress.IsNull() && bytesToWrite > 0)
                        {
                            progress((uint)bytesDownloaded);
                        }
                        if (bytesToWrite == bytesRead && bytesToWrite > 0)
                        {
                            asyncResult = source.BeginRead(buffer, 0, new[] { maxDownloadSize, buffer.Length }.Min(), null, null);
                            // ReSharper disable PossibleNullReferenceException
                            // ReSharper disable AccessToModifiedClosure
                            asyncResult.FromAsync((ia, isTimeout) => endRead(ia, isTimeout), timeout);
                            // ReSharper restore AccessToModifiedClosure
                            // ReSharper restore PossibleNullReferenceException
                        }
                        else
                        {
                            done(null);
                        }
                    }
                    catch (Exception exc)
                    {
                        done(exc);
                    }
                };
            asyncResult.FromAsync((ia, isTimeout) => endRead(ia, isTimeout), timeout);
        }

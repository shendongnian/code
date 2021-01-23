         public static byte[] SerializeAndCompress<T, TStream>(T objectToWrite, Func<TStream> createStream, Func<TStream, byte[]> returnMethod, Action catchAction)
            where T : class
            where TStream : Stream
         {
            if (objectToWrite == null || createStream == null)
            {
                return null;
            }
            byte[] result = null;
            try
            {
                using (var outputStream = createStream())
                {
                    using (var compressionStream = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(compressionStream, objectToWrite);
                    }
                    if (returnMethod != null)
                        result = returnMethod(outputStream);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(Exceptions.ExceptionFormat.Serialize(ex));
                catchAction?.Invoke();
            }
            return result;
        }

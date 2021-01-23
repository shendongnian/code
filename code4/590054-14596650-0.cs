        /// <summary>
        /// Read TCP response, this simple method can be re-used elsewhere as needed later.
        /// </summary>
        /// <returns></returns>
        private static string ReadResponse(NetworkStream networkStream)
        {
            // Check to see if this NetworkStream is readable.
            if (networkStream.CanRead)
            {
                var myReadBuffer = new byte[256]; // Buffer to store the response bytes.
                var completeMessage = new StringBuilder();
                // Incoming message may be larger than the buffer size.
                do
                {
                    var numberOfBytesRead = networkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    completeMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                } while (networkStream.DataAvailable);
                return completeMessage.ToString();
            }
            return null;
        }

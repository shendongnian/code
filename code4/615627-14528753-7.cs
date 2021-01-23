            byte[] inputBlock = new byte[16];
            byte[] outputBlock = new byte[16];
            using (var inputStream = File.OpenRead("input path"))
            using (var outputStream = File.Create("output path"))
            {
                int bytesRead;
                while ((bytesRead = inputStream.Read(inputBlock, 0, inputBlock.Length)) > 0)
                {
                    if (bytesRead < 16)
                    {
                        // Throw or use padding technique.
                        throw new InvalidOperationException("Read block size is not equal to 16 bytes");
                        // Fill the remaining bytes of input block with some bytes.
                        // This operation for last block is called "padding".
                        // See http://en.wikipedia.org/wiki/Block_cipher_modes_of_operation#Padding
                    }
                    Cipher(inputBlock, 0, outputBlock, 0);
                    outputStream.Write(outputBlock, 0, outputBlock.Length);
                }
            }

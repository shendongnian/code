     using (var output = File.Create("output.ts"))
     using (var input = File.OpenRead("input.ts"))
     {
         AppendChunk(output, input, 0, 1174698823L);
         AppendChunk(output, input, 1257553244L, 4126897791L);
     }
     ...
     private static void AppendChunk(Stream output, Stream input,
                                     long start, long end)
     {
         // TODO: Argument validation
         long size = end - start;
         byte[] buffer = new byte[32 * 1024]; // Copy 32K at a time
         input.Position = start;
         while (size > 0)
         {              
             int bytesRead = input.Read(buffer, 0, Math.Min(size, buffer.Length));
             if (bytesRead <= 0)
             {
                 throw new EndOfStreamException("Not enough data");
             }
             output.Write(buffer, 0, bytesRead);
             size -= bytesRead;
         }
     }

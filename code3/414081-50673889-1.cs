      /// <summary>
      /// Method that gets called by ManagedResource.WriteData() in project CodeAnalysis during code 
      /// emitting to get the data for an embedded .resx file. Caller guarantees that the returned
      /// MemoryStream object gets disposed.
      /// </summary>
      /// <param name="resourceFullFilename">full path and filename for .resx file to embed</param>
      /// <param name="targetLessThan4">true if necessary to change System.Drawing from 4.0.0.0 to 2.0.0.0</param>
      /// <returns>MemoryStream containing .resource file data for the .resx file</returns>
      [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
      private static MemoryStream ProvideResourceDataForResx(string resourceFullFilename, 
                                                             bool targetLessThan4)
      {
         MemoryStream shortLivedBackingStream = new MemoryStream();
         using (ResourceWriter resourceWriter = new ResourceWriter(shortLivedBackingStream))
         {
            using (ResXResourceReader resourceReader = new ResXResourceReader(resourceFullFilename))
            {
               IDictionaryEnumerator dictionaryEnumerator = resourceReader.GetEnumerator();
               while (dictionaryEnumerator.MoveNext())
               {
                  string resourceKey = dictionaryEnumerator.Key as string;
                  if (resourceKey != null)  // Should not be possible
                     resourceWriter.AddResource(resourceKey, dictionaryEnumerator.Value);
               }
            }
         }
         // Get reference to the buffer used by shortLivedBackingStream, which is now closed because
         //  resourceWriter was disposed. If relevant, fix version number for System.Drawing.
         byte[] backingStreamBuffer = shortLivedBackingStream.GetBuffer();
         if (targetLessThan4)
            ChangeSystemDrawingVersionNumber(backingStreamBuffer);
         // Create new MemoryStream because shortLivedBackingStream is closed
         return new MemoryStream(backingStreamBuffer);
      }
      /// <summary>
      /// Method to change the System.Drawing version number from "4.0.0.0" to "2.0.0.0" in the
      /// binary data that represents a .resources file. This implementation is based on the
      /// assumption that character data in the .resource file is in UTF-8 encoding.
      /// </summary>
      private static void ChangeSystemDrawingVersionNumber(byte[] dataBuffer)
      {
         byte[] byteArray1 = Encoding.UTF8.GetBytes("System.Drawing, Version=4.0.0.0");
         byte[] byteArray2 = Encoding.UTF8.GetBytes("System.Drawing, Version=2.0.0.0");
         for (int i = 0; i < dataBuffer.Length - byteArray1.Length; i++)
            if (ArrayEquals(byteArray1, dataBuffer, i))
               Array.Copy(byteArray2, 0, dataBuffer, i, byteArray2.Length);
      }
      /// <summary>
      /// Method to test for a byte array in a larger byte array that is being searched. No error
      /// checking is done - it's assumed an indexing error is not possible.
      /// </summary>
      private static bool ArrayEquals(byte[] searchArray, byte[] searchedArray, 
                                      int searchedArrayIndex)
      {
         for (int i = 0; i < searchArray.Length; i++)
            if (searchArray[i] != searchedArray[searchedArrayIndex + i])
               return false;
         return true;
      }

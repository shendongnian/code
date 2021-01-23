      /// <summary>
      /// Method that gets called by ManagedResource.WriteData() in project CodeAnalysis during code 
      /// emitting to get the data for an embedded resource file.
      /// </summary>
      /// <param name="resourceFullFilename">full path and filename for resource file to embed</param>
      /// <returns>MemoryStream containing .resource file data - caller will dispose it</returns>
      private static MemoryStream ProvideResourceData(string resourceFullFilename)
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
         return new MemoryStream(shortLivedBackingStream.GetBuffer());
      }

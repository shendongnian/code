      /// <summary>
      /// Method that gets called by ManagedResource.WriteData() in project CodeAnalysis during code 
      /// emitting to get the data for an embedded resource file.
      /// </summary>
      /// <param name="resourceFullFilename">full path and filename for resource file to embed</param>
      /// <returns>MemoryStream containing .resource file data or image of non-.resx file - caller will dispose it</returns>
      [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
      private static MemoryStream ProvideResourceData(string resourceFullFilename)
      {
         // For non-.resx files just read the file as binary data and return that as a MemoryStream
         if (!resourceFullFilename.EndsWith(".resx", StringComparison.OrdinalIgnoreCase))
            return new MemoryStream(File.ReadAllBytes(resourceFullFilename));
         // Remainder of this method converts a .resx file into .resource file data and returns it
         MemoryStream shortLivedBackingStream = new MemoryStream();
         using (ResourceWriter resourceWriter = new ResourceWriter(shortLivedBackingStream))
         {
            resourceWriter.TypeNameConverter = TypeNameConverter;
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
         // This needed because shortLivedBackingStream is now closed
         return new MemoryStream(shortLivedBackingStream.GetBuffer());
      }
      /// <summary>
      /// This is needed to fix a "Could not load file or assembly 'System.Drawing, Version=4.0.0.0"
      /// exception, although I'm not sure why that exception was occurring.
      ///
      /// See also here: https://github.com/dotnet/corefx/issues/11083 - it says it doesn't work,
      /// but it did save the day for me.
      /// </summary>
      private static string TypeNameConverter(Type objectType)
      {
         // ReSharper disable once PossibleNullReferenceException
         return objectType.AssemblyQualifiedName.Replace("4.0.0.0", "2.0.0.0");
      }

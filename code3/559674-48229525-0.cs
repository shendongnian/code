     /// <summary>
     /// Retrieves the specified [embedded] resource file and saves it to disk.  
     /// If only filename is provided then the file is saved to the default 
     /// directory, otherwise the full filepath will be used.
     /// <para>
     /// Note: if the embedded resource resides in a different assembly use that
     /// assembly instance with this extension method.
     /// </para>
     /// </summary>
     /// <example>
     /// <code>
     ///       Assembly.GetExecutingAssembly().ExtractResource("Ng-setup.cmd");
     ///       OR
     ///       Assembly.GetExecutingAssembly().ExtractResource("Ng-setup.cmd", "C:\temp\MySetup.cmd");
     /// </code>
     /// </example>
     /// <param name="assembly">The assembly.</param>
     /// <param name="resourceName">Name of the resource.</param>
     /// <param name="fileName">Name of the file.</param>
     public static void ExtractResource(this Assembly assembly, string filename, string path=null)
     {
         //Construct the full path name for the output file
         var outputFile = path ?? $@"{Directory.GetCurrentDirectory()}\{filename}";
     
         // If the project name contains dashes replace with underscores since 
         // namespaces do not permit dashes (underscores will be default to).
         var resourceName = $"{assembly.GetName().Name.Replace("-","_")}.{filename}";
     
         // Pull the fully qualified resource name from the provided assembly
         using (var resource = assembly.GetManifestResourceStream(resourceName))
         {
             if (resource == null)
                 throw new FileNotFoundException($"Could not find [{resourceName}] in {assembly.FullName}!");
     
             using (var file = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
             {
                 resource.CopyTo(file);
             }
         }
     }

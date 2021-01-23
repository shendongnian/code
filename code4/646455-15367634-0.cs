            AppDomain.CurrentDomain.AssemblyResolve += ( sender, args ) =>
            {
                try
                {
                    String resourceName = String.Format( "Program.Libs.{0}.dll.gz", new AssemblyName( args.Name ).Name );
                    using (var stream = new GZipStream( Assembly.GetExecutingAssembly().GetManifestResourceStream( resourceName ), CompressionMode.Decompress ))
                    using (var outstream = new MemoryStream())
                    {
                        CopyTo( stream, outstream );
                        return Assembly.Load( outstream.GetBuffer() );
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine( e.ToString() );
                    return null;                	
                }
            };
        public static long CopyTo( Stream source, Stream destination )
        {
            byte[] buffer = new byte[ 2048 ];
            int bytesRead;
            long totalBytes = 0;
            while ((bytesRead = source.Read( buffer, 0, buffer.Length )) > 0)
            {
                destination.Write( buffer, 0, bytesRead );
                totalBytes += bytesRead;
            }
            return totalBytes;
        }

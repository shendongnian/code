    using ( FileStream inputStream = File.OpenRead ( aPackage ) )
    {
        using ( GzipInputStream gzStream = new GzipInputStream ( inputStream ) )
        {
            using ( TarInputStream tarStream = new TarInputStream ( gzStream ) )
            {
                TarEntry entry = tarStream.GetNextEntry();
                while ( entry != null )
                {
                    if ( entry == theOneIWant )
                    {
                        tarStream.CopyEntryContents ( entry, outputStream );
                        break;
                    }
                    entry = tarStream.GetNextEntry();
                }
            }
        }
    }

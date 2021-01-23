        private Stream ConvertPDFtoTiff( Stream filestream ) 
        {
             var ms = new MemoryStream();
            
            var noAppend = new TiffEncoder(TiffCompression.Default, true);
            var pdf = new PdfDecoder();
            for (int i = 0; i < 100; i++)
            {
                var img = pdf.Read(filestream, i, null);
                //When the image is null it will break the loop and return the stream.
                if( img == null )
                {
                    break;
                }
                noAppend.Save(ms, img, null);
                img.Dispose();
                ms.Seek(0, SeekOrigin.Begin);
            }
            return ms;
        }
        private Stream ConvertJPEGtoTIFF( Stream filestream ) 
        {
            var ms = new MemoryStream();
            var jpg = new JpegDecoder();
            var saveJpg = new TiffEncoder();
            var img = jpg.Read( filestream, null );
            saveJpg.Save( ms, img, null );
            img.Dispose();
            ms.Seek( 0, SeekOrigin.Begin );
            return ms;
        }

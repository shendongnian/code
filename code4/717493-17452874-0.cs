    foreach( ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders() ) {
                          if( codec.MimeType == "image/tiff" ) {
                             tiff = codec;
                             break;
                          }
                       }
                       System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.SaveFlag;
                       EncoderParameters parameters = new EncoderParameters( 1 );
                       parameters.Param[ 0 ] = new EncoderParameter( encoder, ( long ) EncoderValue.MultiFrame );
                       bitmap1.Save( newFileName, tiff, parameters );
                       parameters.Param[ 0 ] = new EncoderParameter( encoder, ( long ) EncoderValue.FrameDimensionPage );
                       bitmap1.SaveAdd( bitmap2, parameters );
                       bitmap1.Dispose();
                       bitmap2.Dispose();

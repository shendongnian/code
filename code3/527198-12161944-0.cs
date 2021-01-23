             FourierTransform.FFT2( data, FourierTransform.Direction.Backward );
                fourierTransformed = false;
                for ( int y = 0; y < height; y++ )
                {
                    for ( int x = 0; x < width; x++ )
                    {
                        if ( ( ( x + y ) & 0x1 ) != 0 )
                        {
                            data[y, x].Re *= -1;
                            data[y, x].Im *= -1;
                        }
                    }
                }

      /// <summary>
        /// computes difference between two images and stores result in a third image
        /// input images must be of same dimension and colour depth
        /// </summary>
        /// <param name="imageA">first image</param>
        /// <param name="imageB">second image</param>
        /// <param name="imageDiff">output 0 if same, 255 if different</param>
        /// <param name="width">width of images</param>
        /// <param name="height">height of images</param>
        /// <param name="channels">number of colour channels for the input images</param>
        unsafe void ComputeDiffernece(byte[] imageA, byte[] imageB, byte[] imageDiff, int width, int height, int channels, int threshold)
        {
            int ch = channels;
            fixed (byte* piA = imageB, piB = imageB, piD = imageDiff)
            {
                if (ch > 1) // this a colour image (assuming for RGB ch == 3 and RGBA  == 4)
                {
                    for (int r = 0; r < height; r++)
                    {
                        byte* pA = piA + r * width * ch;
                        byte* pB = piB + r * width * ch;
                        byte* pD = piD + r * width; //this has only one channels!
                        for (int c = 0; c < width; c++)
                        {
                            //assuming three colour channels. if channels is larger ignore extra (as it's likely alpha)
                            int LA = pA[c * ch] + pA[c * ch + 1] + pA[c * ch + 2];
                            int LB = pB[c * ch] + pB[c * ch + 1] + pB[c * ch + 2];
                            if (Math.Abs(LA - LB) > threshold)
                            {
                                pD[c] = 255;
                            }
                            else
                            {
                                pD[c] = 0;
                            }
                        }
                    }
                }
                else //single grey scale channels
                {
                    for (int r = 0; r < height; r++)
                    {
                        byte* pA = piA + r * width;
                        byte* pB = piB + r * width;
                        byte* pD = piD + r * width; //this has only one channels!
                        for (int c = 0; c < width; c++)
                        {
                            if (Math.Abs(pA[c] - pB[c]) > threshold)
                            {
                                pD[c] = 255;
                            }
                            else
                            {
                                pD[c] = 0;
                            }
                        }
                    }
                }
            }
        }

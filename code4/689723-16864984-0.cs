        // create corner strength image and do Harris
        m_CornerImage = new Image<Gray, float>(m_SourceImage.Size);
            CvInvoke.cvCornerHarris(m_SourceImage, m_CornerImage, 3, 3, 0.01);
            // create and show inverted threshold image
            m_ThresholdImage = new Image<Gray, Byte>(m_SourceImage.Size);
            CvInvoke.cvThreshold(m_CornerImage, m_ThresholdImage, 0.0001, 255.0, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV);
            imageBox2.Image = m_ThresholdImage;
            imageBox1.Image = m_CornerImage;
            const double MAX_INTENSITY = 255;
            int contCorners = 0; 
            for (int x = 0; x < m_ThresholdImage.Width; x++)
            {
                for (int y = 0; y < m_ThresholdImage.Height; y++)
                {
                    Gray imagenP = m_ThresholdImage[y,x];
                    if (imagenP.Intensity == MAX_INTENSITY)
                    {
                        //X and Y are harris point cordenates 
                    }
                }
            } 

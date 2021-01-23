        private int maxPointCount = 16;
        private CvPoint2D32f[] points = new CvPoint2D32f[maxPointCount];
        private CvImage grayImage = new CvImage(size, CvColorDepth.U8, CvChannels.One);
        private CvImage eigenValues = new CvImage(size, CvColorDepth.F32, CvChannels.One);
        private CvImage tempImage = new CvImage(size, CvColorDepth.F32, CvChannels.One);
        public int FeatureRadius { get; set; }
        private CvScalar featureColor; 
        public Color FeatureColor
        {
            get
            {
                return Color.FromArgb((byte)featureColor.Value2, (byte)featureColor.Value1, (byte)featureColor.Value0);
            }
            set
            {
                featureColor.Value0 = value.B;
                featureColor.Value1 = value.G;
                featureColor.Value2 = value.R;
            }
        }
        public void Process(CvImage input, CvImage output)
        {
            CV.ConvertImage(input, grayImage);
            CV.GoodFeaturesToTrack(grayImage, eigenValues, tempImage, points, ref maxPointCount, 0.01, 10, IntPtr.Zero, 3, 0, 0.04);
            CV.Copy(input, output);
            // This draws a circle around the feature points found
            for (int i = 0; i < pointCount; i++)
                CV.Circle(output, new CvPoint((int)points[i].X, (int)points[i].Y), FeatureRadius, featureColor);
        }

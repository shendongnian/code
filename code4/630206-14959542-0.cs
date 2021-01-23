    Bgr[] clusterColors = new Bgr[] {
            new Bgr(0,0,255),
            new Bgr(0, 255, 0),
            new Bgr(255, 100, 100),
            new Bgr(255,0,255),
            new Bgr(133,0,99),
            new Bgr(130,12,49),
            new Bgr(0, 255, 255)};
            Image<Bgr, float> src = new Image<Bgr, float>("fotobp.jpg");            
            Matrix<float> samples = new Matrix<float>(src.Rows * src.Cols, 1, 3);
            Matrix<int> finalClusters = new Matrix<int>(src.Rows * src.Cols, 1);
            
            for (int y = 0; y < src.Rows; y++)
            {
                for (int x = 0; x < src.Cols; x++)
                {                    
                    samples.Data[y + x * src.Rows, 0] = (float)src[y, x].Blue;
                    samples.Data[y + x * src.Rows, 1] = (float)src[y, x].Green;
                    samples.Data[y + x * src.Rows, 2] = (float)src[y, x].Green;
                }
            }
            MCvTermCriteria term = new MCvTermCriteria(100, 0.5);
            term.type = TERMCRIT.CV_TERMCRIT_ITER | TERMCRIT.CV_TERMCRIT_EPS;
            int clusterCount = 4;            
            int attempts = 5;
            Matrix<Single> centers = new Matrix<Single>(clusterCount, src.Rows * src.Cols);            
            CvInvoke.cvKMeans2(samples, clusterCount, finalClusters, term, attempts, IntPtr.Zero, KMeansInitType.PPCenters, IntPtr.Zero, IntPtr.Zero);
            Image<Bgr, float> new_image = new Image<Bgr, float>(src.Size);
            
            for (int y = 0; y < src.Rows; y++)
            {
                for (int x = 0; x < src.Cols; x++)
                {
                    PointF p = new PointF(x, y);
                    new_image.Draw(new CircleF(p, 1.0f), clusterColors[finalClusters[y + x * src.Rows, 0]], 1);
                }
            }
            CvInvoke.cvShowImage("clustered image", new_image);
            CvInvoke.cvWaitKey(0);

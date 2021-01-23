       private void ComputeProjections(Image<Bgr, byte> inputImage)
        {                        
            Image<Gray, Byte> inputGrayImage = inputImage.Convert<Gray, Byte>();
            Matrix<float> imgMatHorizontal = new Matrix<float>(inputGrayImage.Height, 1, 1);
            Matrix<float> imgMatVertical = new Matrix<float>(1, inputGrayImage.Width, 1);
            inputGrayImage.Reduce<float>(imgMatHorizontal, REDUCE_DIMENSION.SINGLE_COL, REDUCE_TYPE.CV_REDUCE_AVG);
            inputGrayImage.Reduce<float>(imgMatVertical, REDUCE_DIMENSION.SINGLE_ROW, REDUCE_TYPE.CV_REDUCE_AVG);
            double minH, maxH, minV, maxV;
            Point minLocH, maxLocH, minLocV, maxLocV;
            imgMatHorizontal.MinMax(out minH, out maxH, out minLocH, out maxLocH);
            imgMatVertical.MinMax(out minV, out maxV, out minLocV, out maxLocV);
            Image<Gray, Byte> maskProvaH = new Image<Gray, byte>(new Size((int)(maxH - minH + 1), imgMatHorizontal.Rows));
            Image<Gray, Byte> maskProvaV = new Image<Gray, byte>(new Size(imgMatVertical.Cols, (int)(maxV - minV + 1)));
            for (int i = 0; i < imgMatHorizontal.Rows; i++)
                maskProvaH.Draw(new CircleF(new PointF((float)(imgMatHorizontal[i, 0] - minH), i), 1f), new Gray(255), 1);
            for (int i = 0; i < imgMatVertical.Cols; i++)
                maskProvaV.Draw(new CircleF(new PointF(i, (float)(imgMatVertical[0, i] - minV)), 1f), new Gray(255), 1);
            inputImage.Draw(new CircleF(new PointF(minLocV.X, minLocH.Y), 2), new Bgr(Color.Green), 1);
            //imageBoxProjected.Image = inputGrayImage;
            imageBoxHorizProj.Image = maskProvaH;
            //imageBoxVerticProj.Image = maskProvaV;
        }

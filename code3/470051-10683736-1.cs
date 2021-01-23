      using(DepthImageFrame depthFrame = e.OpenDepthImageFrame())
      {
            if (depthFrame == null)
                return;
            depthImagePixels = GenerateDepthImage(depthFrame);
            int stride = depthFrame.Width*4;
            image1.Source =
                BitmapSource.Create(depthFrame.Width, depthFrame.Height,
                96, 96, PixelFormats.Bgr32, null, depthImagePixels, stride);
            //Get a skeleton
            Skeleton first = GetFirstSkeleton(e);
            if (first == null)
                return;
            Debug.WriteLine("Head Position is : " + first.Joints[JointType.Head].ToString());
         }

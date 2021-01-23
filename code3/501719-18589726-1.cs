    using System;
    using Emgu.CV;
    using Emgu.CV.GPU;
    using System.Drawing;
    using Emgu.CV.Structure;
    using System.Diagnostics;
    using System.Collections.Generic;
    namespace Video
    {
    //-----------------------------------------------------------------------------------
    //  Copyright (C) 2004-2012 by EMGU. All rights reserved. Modified by Chris Sykes. 
    //-----------------------------------------------------------------------------------
    public static class DetectFace
    {
    // Use me like this:
    /*
    //Emgu.CV.GPU.GpuInvoke.HasCuda
    if (GpuInvoke.HasCuda)
    {
    DetectUsingGPU(...);
    }
    else
    {
    DetectUsingCPU(...);
    }
    */
    private static Stopwatch watch;
    public static void UsingGPU(Image<Bgr, Byte> image, GpuCascadeClassifier face, GpuCascadeClassifier eye, List<Rectangle> faces, List<Rectangle> eyes, out long detectionTime)
    {
    watch = Stopwatch.StartNew();
    using (GpuImage<Bgr, Byte> gpuImage = new GpuImage<Bgr, byte>(image))
    using (GpuImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
    {
    Rectangle[] faceRegion = face.DetectMultiScale(gpuGray, 1.1, 10, Size.Empty);
    faces.AddRange(faceRegion);
    foreach (Rectangle f in faceRegion)
    {
    using (GpuImage<Gray, Byte> faceImg = gpuGray.GetSubRect(f))
    {
    //For some reason a clone is required.
    //Might be a bug of GpuCascadeClassifier in opencv
    using (GpuImage<Gray, Byte> clone = faceImg.Clone())
    {
    Rectangle[] eyeRegion = eye.DetectMultiScale(clone, 1.1, 10, Size.Empty);
    foreach (Rectangle e in eyeRegion)
    {
    Rectangle eyeRect = e;
    eyeRect.Offset(f.X, f.Y);
    eyes.Add(eyeRect);
    }
    }
    }
    }
    }
    watch.Stop();
    detectionTime = watch.ElapsedMilliseconds;
    }
    public static void UsingCPU(Image<Bgr, Byte> image, CascadeClassifier face, CascadeClassifier eye, List<Rectangle> faces, List<Rectangle> eyes, out long detectionTime)
    {
    watch = Stopwatch.StartNew();
    using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>()) //Convert it to Grayscale
    {
    //normalizes brightness and increases contrast of the image
    gray._EqualizeHist();
    //Detect the faces  from the gray scale image and store the locations as rectangle
    //The first dimensional is the channel
    //The second dimension is the index of the rectangle in the specific channel
    Rectangle[] facesDetected = face.DetectMultiScale(gray, 1.1, 10, new Size(20, 20), Size.Empty);
    faces.AddRange(facesDetected);
    foreach (Rectangle f in facesDetected)
    {
    //Set the region of interest on the faces
    gray.ROI = f;
    Rectangle[] eyesDetected = eye.DetectMultiScale(gray, 1.1, 10, new Size(20, 20), Size.Empty);
    gray.ROI = Rectangle.Empty;
    foreach (Rectangle e in eyesDetected)
    {
    Rectangle eyeRect = e;
    eyeRect.Offset(f.X, f.Y);
    eyes.Add(eyeRect);
    }
    }
    }
    watch.Stop();
    detectionTime = watch.ElapsedMilliseconds;
    }
    } // END of CLASS...
    }// END of NAMESPACE...

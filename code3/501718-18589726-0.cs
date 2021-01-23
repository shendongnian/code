    List<Rectangle> faces = new List<Rectangle>();
    List<Rectangle> eyes = new List<Rectangle>();
    RightCameraImage = RightCameraImageCapture.QueryFrame().Resize(480, 360, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC); //Read the files as an 8-bit Bgr image
    //Emgu.CV.GPU.GpuInvoke.HasCuda
    if (GpuInvoke.HasCuda)
    {
    Video.DetectFace.UsingGPU(RightCameraImage, Main.FaceGpuCascadeClassifier, Main.EyeGpuCascadeClassifier, faces, eyes, out detectionTime);
    }
    else
    {
    Video.DetectFace.UsingCPU(RightCameraImage, Main.FaceCascadeClassifier, Main.EyeCascadeClassifier, faces, eyes, out detectionTime);
    }
    string PersonsName = string.Empty;
    Image<Gray, byte> GreyScaleFaceImage;
    foreach (Rectangle face in faces)
    {
    RightCameraImage.Draw(face, new Bgr(Color.Red), 2);
    GreyScaleFaceImage = RightCameraImage.Copy(face).Convert<Gray, byte>().Resize(200, 200, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
    if (KnownFacesList.Count > 0)
    {
    // MCvTermCriteria for face recognition...
    MCvTermCriteria mCvTermCriteria = new MCvTermCriteria(KnownFacesList.Count, 0.001);
    // Recognize Known Faces with Eigen Object Recognizer...
    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(KnownFacesList.ToArray(), KnownNamesList.ToArray(), eigenDistanceThreashhold, ref mCvTermCriteria);
    EigenObjectRecognizer.RecognitionResult recognitionResult = recognizer.Recognize(GreyScaleFaceImage);
    if (recognitionResult != null)
    {
    // Set the Persons Name...
    PersonsName = recognitionResult.Label;
    // Draw the label for each face detected and recognized...
    RightCameraImage.Draw(PersonsName, ref mCvFont, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
    }
    else
    {
    // Draw the label for each face NOT Detected...
    RightCameraImage.Draw(FaceUnknown, ref mCvFont, new Point(face.X - 2, face.Y - 2), new Bgr(Color.LightGreen));
    }
    }
    }

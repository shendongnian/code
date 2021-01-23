    Image<Gray, System.Single> _image = new Image<Gray, System.Single>("c://box1.png");
    Image<Gray, System.Single> DFTimage = new Image<Gray, System.Single>(_image.Size);
    Image<Gray, System.Single> Original = new Image<Gray, System.Single>(_image.Size);
    CvInvoke.cvDFT(_image.Ptr, DFTimage.Ptr,Emgu.CV.CvEnum.CV_DXT.CV_DXT_FORWARD, -1);
    CvInvoke.cvDFT(DFTimage.Ptr, Original.Ptr,Emgu.CV.CvEnum.CV_DXT.CV_DXT_INVERSE, -1);
    CvInvoke.cvShowImage("picture", Original);

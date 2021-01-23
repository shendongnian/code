    class ImageFinder
    {
        private List<Rectangle> rectangles;  
		public Image<Bgr, byte> BaseImage { get; set; }
        public Image<Bgr, byte> SubImage { get; set; }
        public Image<Bgr, byte> ResultImage { get; set; }
        public double Threashold { get; set; }        
        public List<Rectangle> Rectangles
        {
            get { return rectangles; }
        }
        public ImageFinder(Image<Bgr, byte> baseImage, Image<Bgr, byte> subImage, double threashold)
        {
            rectangles = new List<Rectangle>();            
            BaseImage = baseImage;
            SubImage = subImage;
            Threashold = threashold;            
        }
        public void FindThenShow()
        {
            FindImage();
            DrawRectanglesOnImage();
            ShowImage();
        }
        public void DrawRectanglesOnImage()
        {
            ResultImage = BaseImage.Copy();
            foreach (var rectangle in this.rectangles)
            {
                ResultImage.Draw(rectangle, new Bgr(Color.Blue), 1);
            }
        }
        public void FindImage()
        {          
            rectangles = new List<Rectangle>();           
            using (Image<Bgr, byte> imgSrc = BaseImage.Copy())
            {
                while (true)
                {
                    using (Image<Gray, float> result = imgSrc.MatchTemplate(SubImage, TemplateMatchingType.CcoeffNormed))
                    {
                        double[] minValues, maxValues;
                        Point[] minLocations, maxLocations;
                        result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                        if (maxValues[0] > Threashold)
                        {
                            Rectangle match = new Rectangle(maxLocations[0], SubImage.Size);
                            imgSrc.Draw(match, new Bgr(Color.Blue), -1);
                            rectangles.Add(match);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }          
           
        }
        public void ShowImage()
        {
            Random rNo = new Random();
            string outFilename = "matched Templates" + rNo.Next();            
            CvInvoke.Imshow(outFilename, ResultImage);
        }     
    }

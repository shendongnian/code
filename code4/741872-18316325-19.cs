    public static class GraphicsLibrary
    {
        public Image RotateImage(Image image, Double angleInDegrees)
        {
           Sqm.TimerStart("GraphicaLibrary.RotateImage");
           ...
           Sqm.TimerStop("GraphicaLibrary.RotateImage");
        }
    }

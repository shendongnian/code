    public static class FrameUtil{
         public RectangleF UpdateX(RectangleF frame, float newX){
              var tempFrame = frame;
              tempFrame.x = newX;
              return tempFrame;
         }
    }

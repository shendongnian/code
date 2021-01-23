    public static class ControlExtension {
       public static bool IsRightToLeft(this Control c){
          return c.RightToLeft == RightToLeft.Inherit ? (c.Parent != null ? IsRightToLeft(c.Parent) : false) : c.RightToLeft == RightToLeft.Yes;
       }
    }

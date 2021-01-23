    public class PermaToolTip : ToolTip
    {
         public PermaToolTip()
         {
            // Define defaults differently now
            this.ShowAlways = true;
            this.IsBalloon = true;
            this.AutomaticDelay = 750;
            this.AutoPopDelay = 32767;
         }
    }

    public class ShakeAnimationEffect : IAnimationEffect
    {
        public IComponent TargetComponent { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        // Some shake specific properties can be added, to control the type of vibration etc 
        // (could be a rotating vibration an updown shake), but these really should have dedicated classes of their own.
        public void CalculateFrame(int frame)
        {
            // your maths manipulations for calculating the bounds of the IComponent go here
        }
    }
    public class TranslateAnimation : IAnimationEffect
    {
        public IComponent targetComponent { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public int TranslateX { get; set; } 
        public int TranslateY { get; set; }
        public void CalculateFrame(int frame)
        {
            // your maths manipulations for calculating the bounds of the IComponent go here
        }
    }
 

    public interface IAnimationEffect
    {
        IComponent targetComponent;
        int StartFrame { get; set; }
        int EndFrame { get; set; }
        void CalculateFrame(int frame);
    }

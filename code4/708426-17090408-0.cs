    public interface ICube
    {
        ICollection<IColor> sideColors { get; set; }
    }
    public interface IColor
    {
        float getHue();
    }
    internal class Cube : ICube
    {
        public ICollection<IColor> sideColors { get; set; }
    }
    internal class Color : IColor
    {
        public Color(float r, float g, float b)
        {
        }
        public float getHue()
        { 
        }
        
    }

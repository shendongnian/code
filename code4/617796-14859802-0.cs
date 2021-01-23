    public class FloatingPointSingle : AbstractElement<float[]>
    {
        public FloatingPointSingle() { }
        public FloatingPointSingle(Tag tag, float[] data)
        {    
            Tag = tag;
            Data = data;
            VR = Enums.VR.FloatingPointSingle;
        }
    }

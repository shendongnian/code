    public class Part
    {
        public virtual string Name { get { return "not specified"; } }
        public virtual string FileName { get { return "not specified"; } }
        public virtual string Layer2D { get { return "not specified"; } }
        public virtual string Layer3D { get { return "not specified"; } }
        ...
    }
    public class Monitor : Part
    {
        public override FileName { get { return "default monitor"; } }
        public override Layer2d { get { return "default monitor layer"; }}
        ...
    }

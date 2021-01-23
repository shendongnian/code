    public class Body : ISkeleton
    {
        private SkeletonImpl _skeleton = new SkeletonImpl;
    
        public IEnumerable<IBone> Bones { get { return _skeleton.Bones; } }
    
        public void Attach(IBone bone)
        {
            _skeleton.Attach(bone);
        }
    
        public void Detach(IBone bone)
        {
           _skeleton.Detach(bone);
        }
    }

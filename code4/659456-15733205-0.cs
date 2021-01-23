    interface ITag<in TTag> where TTag : ITag<TTag>
    {
        bool Contains(TTag tag);
    }
    
    class Tag : ITag<Tag> 
    {
        public bool Contains(Tag t)
        {
            return false;
        }
    }

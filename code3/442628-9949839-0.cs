    interface ICommon { ... }
    class AskAdaptor: ICommon
    {
        private readonly Ask ask;
        publick AskAdaptor(Ask ask)
        {
            this.ask = ask;
        }
    }
    class AskAdaptor: ICommon
    {
        private readonly Blog blog;
        publick AskAdaptor(Blog blog)
        {
            this.blog = blog;
        }
    }
    class AskAdaptor: ICommon
    {
        private readonly Resource resource;
        publick AskAdaptor(Resource resource)
        {
            this.resource = resource;
        }
    }
    class CommonAggregate
    {
        public void Add(ICommon common)
        {
             ....
        }
    }

    interface IMockManager<Req, Res>
        where Req : MockRequestObject
        where Res : IMockResponseObject<IComparable>
    {
    }
    public class ToPos : MockBaseObject, IMockResponseObject<string>
    {
        public string Content
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public DateTime CreationDate
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

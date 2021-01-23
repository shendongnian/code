    public interface IBase { }
    public interface IBookObject : IBase { }
    public interface ITapeObject : IBase { }
    public class Book : IBookObject { }
    public interface IModelObject
    {
        IBase ModelObject { get; set; } // might be a book or tape , etc
    }
    public class GraphicObject<T> : IModelObject
        where T: class, IBase
    {
        public T ModelObject { get; set; }
        #region IModelObject Members
        IBase IModelObject.ModelObject
        {
            get
            {
                return ModelObject;
            }
            set
            {
                ModelObject=value as T;
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            IBookObject bk=new Book();
            var go=new GraphicObject<IBookObject>(); // will fail later
            
            //var go = new GraphicObject<IBase>(); // will succeed later
            go.ModelObject=bk;
            if(go is IModelObject) // can't use is IModelObject<IBookObject> as go might be GraphicObject<ITapeObject>
            {
                Debug.WriteLine("Success");
            }
        }
    }

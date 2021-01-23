    interface IRepository<T> where T : Base
    {
        T MakeSomeItem(string info);
        void AddSomeItem(string info, T itemToAdd)
    }
    
    public class Repository<T> : IRepository<Base>, IRepository<T> where T : Base
    {
        public T MakeSomeItem(string info) { throw new NotImplementedException(); }
        
        public void AddSomeItem(string info, Base itemToAdd)
        {
            T castedItem = (T) itemToAdd; //fails here at 
                                          //run time if not 
                                          // correct type
            AddSomeItem(info, itemToAdd);
        }
    
        public void AddSomeItem(string info, T itemToAdd)
        {
            /// do it for real...
        }
    
        Base IRepository<Base>.MakeSomeItem(string info)
        {
            return MakeSomeItem(info);
        }
    }

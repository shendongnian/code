    [DataContract]
    public class BusinessObject<T> where T : IEntity
    {
        [DataMember]
        public T Entity { get; set; }
    
        public BusinessObject(T entity)
        {
            this.Entity = entity;
        }
    }  
    [ServiceContract]
    interface IMyContract {
    [OperationContract]
    BusinessObject<Student> GetStudent(...) // must be closed generic
    }

    interface IDeleteObjectCommand {
       Guid ObjectId { get; }
       DeleteObjectPreconditions? GetImpediments();
       // Contract.Requires(!this.GetImpediments().HasValue);
       void Invoke();
    }
    
    enum DeleteObjectPreconditions { ObjectExists, ObjectUnlocked };

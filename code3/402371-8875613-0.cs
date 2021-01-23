    interface IFoo {
        Int32 Id { get; }
    }
    abstract class MutableFoo: IFoo {
        public abstract Int32 Id {get; set;}
    }

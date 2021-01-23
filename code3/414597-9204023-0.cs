    //Could be an abstract, but an interface is better here
    public interface ICanRead
    {
        void ReadOne(IDataReader dr);
    }
    public class B : ICanRead
    {
        public int MyInt {get;set;}
        //The interface implementation can be private to 'hide' it from the public
        void ICanRead.ReadOne(IDataReader dr)
        {
            Read(dr);
        }
        protected virtual void Read(IDataReader dr)
        {
            MyInt = (Int32)dr["MyInt"];
        }
    }
    public class A : B
    {
        public int MyOtherInt {get;set;}
        protected override void Read(IDataReader dr)
        {
            base.Read(dr);
            MyOtherInt = (Int32)dr["MyOtherInt"];
        }
    }

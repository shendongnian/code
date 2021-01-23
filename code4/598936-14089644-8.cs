    using System.Transactions;
    
    namespace Sakher.Transactions
    {
        public class  Royi_s_gReturnerClass 
        {
            private GReturnerEnlistment fileTransactionEnlistment = new GReturnerEnlistment();
            public Royi_s_gReturnerClass()
            {
                Transaction.Current.EnlistVolatile(fileTransactionEnlistment, EnlistmentOptions.None);
            }
        }
    
        public class GReturnerEnlistment : IEnlistmentNotification
        {
            public int GOldValue { get; set; }
    
            public GReturnerEnlistment()
            {
                GOldValue = MyClass.g;
            }
    
            public void Commit(Enlistment enlistment)
            {
    
            }
    
            public void InDoubt(Enlistment enlistment)
            {
    
            }
    
            public void Prepare(PreparingEnlistment preparingEnlistment)
            {
                preparingEnlistment.Prepared();
            }
    
            public void Rollback(Enlistment enlistment)
            {
                MyClass.g = GOldValue;
            }
        }
    
    }

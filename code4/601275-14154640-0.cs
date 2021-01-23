    using System;
    using PaymentPlanLogic;
    namespace PaymentPlanStoreLogic
    {
        public class Class1
        {
            #region Members
            
            Logger myLog;
            #endregion
            #region Constructors
            public Class1()
            {
                myLog = new Logger();
                myLog.createLog();
            }
            #endregion
        }
    }

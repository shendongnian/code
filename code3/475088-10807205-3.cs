    using System;
    namespace UComment.OtherNamespace
    {
        public class MyOtherClass
        {
             public void MyMethod()
             {
                 UComment.Domain.Comment c = new UComment.Domain.Comment();
                 c.EmailNotification(1);
             }
        }
    }

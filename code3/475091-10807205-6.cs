    using System;
    using UComment.Domain;
    namespace UComment.OtherNamespace
    {
        public class MyOtherClass
        {
             public void MyMethod()
             {
                 Comment c = new Comment();
                 c.EmailNotification(1);
             }
        }
    }

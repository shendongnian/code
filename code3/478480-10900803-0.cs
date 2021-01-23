    public interface IYourCommonInterface
    {
         string LogMsgNo { get; set; };
         string RevNo { get; set; };
         string ReqSox { get; set; };
         void DoSomething();
    }
    
    
    public class Foobar : IYourCommonInterface
    {
         public string Logmsgno;
         public string Revno;
         public string Reqsox;
         public void Dosomething();
    
         // these are the implementations of the interface...
         public string LogMsgNo
         { get { return Logmsgno; }
           set { Logmsgno = value; }
         }
    
         public string RevNo
         { get { return Revno; }
           set { Revno = value; }
         }
    
         public string ReqSox
         { get { return Reqsox; }
           set { Reqsox = value; }
         }
    
         public void DoSomething()
         { Dosomething(); }
    
    }
    
    public class FooBar : IYourCommonInterface
    {
         // since THIS version has the proper naming constructs you want,
         // change the original properties to lower case start character
         // so the interface required getter/setter will be properly qualified
    
         public string logMsgNo;
         public string revNo;
         public string reqSox;
    
         // these are the implementations of the interface...
         public string LogMsgNo
         { get { return logMsgMo; }
           set { logMsgNo = value; }
         }
    
         public string RevNo
         { get { return revNo; }
           set { revNo = value; }
         }
    
         public string ReqSox
         { get { return reqSox; }
           set { reqSox = value; }
         }
    
    
         // Since your "DoSomething()" method was already proper case-sensitive
         // format, you can just leave THIS version alone
         public void DoSomething()
         { .. do whatever .. }
    }

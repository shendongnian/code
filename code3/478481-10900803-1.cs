    public interface IYourBarBazInterface
    {
         string BarBazProp1 { get; set; }
         string AnotherProp { get; set; }
    }
    public interface IQuux
    {
        int QuuxProp { get; set; }
        string AnotherQuuxProp { get; set; }
    }
    public interface IYourCommonInterface
    {
         string LogMsgNo { get; set; };
         string RevNo { get; set; };
         string ReqSox { get; set; };
         // Similar principle of declarations, but interface typed objects
         IYourBarBazInterface MyBarBaz { get; set; }
         List<IQuux> MyQuuxList;
         void DoSomething();
    }
    
    
    public class Foobar : IYourCommonInterface
    {
         public string Logmsgno;
         public string Revno;
         public string Reqsox;
         public void Dosomething();
         // your existing old versions keep same name context
         // but showing each of their respective common "interfaces"
         public IYourBarBazInterface mybarbaz;
         public List<IQuux> myQuuxlist = new List<IQuux>();
    
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
         // Now, the publicly common Interface of the "IYourCommonInterface"
         // that identify the common elements by common naming constructs.
         // similar in your second class.
         public IYourBarBazInterface MyBarBaz 
         { get { return mybarbaz; }
           set { mybarbaz = value; }
         }
         public List<IQuux> MyQuuxList
         { get { return myQuuxlist; }
           set { myQuuxlist = value; }
         }
    }
    
    public class FooBar : IYourCommonInterface
    {
         // since THIS version has the proper naming constructs you want,
         // change the original properties to lower case start character
         // so the interface required getter/setter will be properly qualified
    
         public string logMsgNo;
         public string revNo;
         public string reqSox;
         public IYourBarBazInterface MyBarbaz;
         public List<IQuux> Myquuxlist;
    
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
         public IYourBarBazInterface MyBarBaz 
         { get { return MyBarbaz; }
           set { MyBarbaz = value; }
         }
         public List<IQuux> MyQuuxList
         { get { return myquuxlist; }
           set { myquuxlist = value; }
         }
    }

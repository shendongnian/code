    public class AppDomainArgs : MarshalByRefObject
    {
        public StringBuilder MyStringBuilder { get; set; }
    }
    public void SomeMethod(AppDomainArgs ada)
    {
        Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + "; executing");
        ada.MyString = "working!";
        ada.MyStringBuilder.Append(" working!");
    }

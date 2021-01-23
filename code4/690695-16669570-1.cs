    public partial class MyDomainContext
    {
        partial void OnCreated()
        {
            this.ChangeTimeout(new TimeSpan(0,10,0));
        }
    }

    [System.Diagnostics.DebuggerDisplay("ParentName = '{ParentName}', MyKidsCount='{null == MyKids ? 0 : MyKids.Count}'")]
    public class MyParent
    {
        public string ParentName { get; set; }
    
        public ICollection<MyKid> MyKids { get; set; }
    }

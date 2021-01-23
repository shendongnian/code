    [Serializable]
    public partial class MyObject
    {
       [IgnoreDataMember]
       public MyOtherObject MyOtherObject => MyOtherObject.GetById(MyOtherObjectId);
    }
    
    [Serializable]
    public partial class MyOtherObject
    {
       [IgnoreDataMember]
       public List<MyObject> MyObjects => MyObject.GetByMyOtherObjectId(Id);
    }

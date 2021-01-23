    [Serializable]
    class SomeClass
    {
    //does not persist the member in your serialization process
     [NonSerialized]
     private bool trueOrFalse = false;
     public bool TrueOrFalse
     {
        get { return trueOrFalse; }
        set { trueOrFalse = value; }
     }
   }

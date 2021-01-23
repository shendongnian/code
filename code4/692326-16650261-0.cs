    public class Foo : System.Collections.CollectionBase
    {
        public Bar FirstItem
        {
            get { return this[0] as SomeObject;
        }
        #region Coming From CollectionBase
        public Object this[ int index ]  {
            get { return this.InnerList[index]; }
            set { this.InnerList[index] = value; }
        }
        #endregion
    }

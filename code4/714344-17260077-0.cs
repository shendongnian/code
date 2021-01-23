    public class MyTypes
    {
        #region Enum Values
        public static MyTypes RandomType = new MyTypes(0, "Random Type");
        public static MyTypes NewRandom = new MyTypes(1, "New Random");
        #endregion
        #region Private members
        private int id;
        private string value;
        private MyTypes(int id, string value)
        {
            this.id = id;
            this.value = value;
        }
        #endregion
        #region Overriden members
        public override string ToString()
        {
            return value;
        }
        #endregion
        public static List<MyTypes> GetValues()
        {
            return new List<MyTypes>() { MyTypes.RandomType, MyTypes.NewRandom };
        }
    }

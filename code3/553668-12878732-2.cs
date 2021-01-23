    public class MenuTest
    {
        Dictionary<MenuType, string> myarray;
        public MenuTest()
        {
            myarray = new Dictionary<MenuType, string>();
        }
        public string this[MenuType index]
        {
            get
            {
                if (myarray.ContainsKey(index))
                    return myarray[index];
                else
                    return null;
            }
            set
            {
                myarray[index] = value;
            }
        }
    }

    public class MyValidator
    {
        public bool IsValidate(string Item)
        {
            string Result = Item;
            int val;
            if (int.TryParse(Item, out val) && val > 0 && val < 1000)
            {
                return true;
            }
            else
            {
                return false;
            }
    
        }
    }

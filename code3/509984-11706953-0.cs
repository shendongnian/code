    public class Item
    {
        public string _name;
        public double _weight;
        public decimal _wholesalePrice;
        public int _quantity;
        public Item(string name, double weight, decimal wholesalePrice, int quantity)
        {
            _name = name;
            _weight = weight;
            _wholesalePrice = wholesalePrice;
            _quantity = quantity;
        }
        public static bool operator ==(Item left, Item right)
        {
            if (left._name == right._name)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Item left, Item right)
        {
            return !(left == right);
        }
    }

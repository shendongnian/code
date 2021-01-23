    class Menu
    {
        public readonly string[] pizza = { "Cheese and Ham", "Ham and Pineapple", "Vegetarian", "MeatFeast", "Seafood" };
        public readonly double[] price = { 3.50, 4.20, 5.20, 5.80, 5.60 };
        public string GetMenuItem(int select)
        {
            string choice = pizza[select];
            return choice;
        }
    }

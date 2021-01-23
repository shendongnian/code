     Dictionary<string, string> Restaurants = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            Restaurants.Add("Location 1", "ABC Restaurant");
            Restaurants.Add("Location 2", "ABD Restaurant");
            Restaurants.Add("Location 3", "ABE Restaurant");
            Restaurants.Add("Location 4", "ABF Restaurant");
            Restaurants.Add("Location 5", "ABG Restaurant");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( getRestaurant("Mike has to walk a mile facing north to reach Location 2"));
         // Result: Mike has to walk a mile facing north to reach ABD Restaurant
        }
        private String getRestaurant(String msg)
        {
            String restaurantName = "";
            foreach (String loc in Restaurants.Keys)
            {
                if (msg.Contains(loc))
                {
                    restaurantName = msg.Replace(loc, Restaurants[loc]);
                    break;
                }
            }
            return  String.IsNullOrEmpty(restaurantName) ? msg : restaurantName;
        }

    public class OrderMenuItem
    {
        public int OrderMenuItemId { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } // Pizza Margherita
        public ICollection<MenuItemExtras> MenuItemExtras { get; set; }
        // Ordered Extras: Paprika and Mushrooms (subset of Possible Extras)
    }

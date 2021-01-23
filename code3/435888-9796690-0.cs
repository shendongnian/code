    class NewItemViewController : DialogViewController
    {
        private Item _item;
        public NewItemViewController(bool pushing) : base(null, pushing)
        {
            _item = new Item();
            BindingContext bc = new BindingContext(this, _item, "Add Item");
            this.Root = bc.Root;
            // more setup
        }
        // more methods
    }

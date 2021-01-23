        private static MyBindableObject _bindingContainer = new MyBindableObject();
        public static MyBindableObject BindingContainer
        {
            get { return _bindingContainer; }
        }
        public static void SetNewData()
        {
            // use this anywhere to update the value
            App.BindingContainer.DateStr = "<Your New Value>";
        }

    class Tab
    {
        public delagate void MyOnGUI(); // Declare the delegate
        
        private MyOnGUI onGUI;  // An instance of the delegate
          
        public Tab(string s, MyOnGUI onGUI)
        {
            this.onGUI = onGUI;
            //...
        }
        
        public void OnGUI()
        {
            onGUI(); // Call the delegate
        }
    }
    // ...
    
    tabs.addTab(new Tab("test", delegate(){
        // Your code here
        });

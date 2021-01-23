    public static class NavigationUtility
    {
        // The object to send
        private static object passedObject = null;
        // A method to fetch the object
        public static object GetObject() {
            // implementation below
        }
        // Utility method to check if an object was passed
        public static bool HasObject() 
        {
            return passedObject != null;
        }
     
        // A method to navigate to a page
        public static void Navigate(string url, object obj = null)
        {
            // implementation below
        }
    }

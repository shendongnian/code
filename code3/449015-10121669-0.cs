    class MyDateTime
    {
        public static explicit operator DateTime(MyDateTime dt)
        {
            return new DateTime(); // Convert dt here            
        }
    }

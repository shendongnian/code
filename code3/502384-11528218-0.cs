    public static MyComponent
    {
        static MyComponent()
        {
             // Check for licensing here.
             if (!<licensing condition>)
             {
                 // Bomb the app.
                 throw new InvalidOperationException("Component is not licensed.");
             }
        }
    }

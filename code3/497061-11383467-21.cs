    class Asteroid
    {
        // Static variables are shared between all instances of a class
        static Texture2D asteroidTexture;
        
        // Non-static variables exist once for each instance of the class
        Vector2 position;
        // Constants are fixed at compile time and cannot be modified
        const float asteroidSpeed = 50; // units per second
    }
    // A static class can only contain static variables (and constants)
    // (You can't create an instance of it, so you can't have variables.)
    static class Shared
    {
        // "readonly" prevents anyone from writing to a field after it is initialised
        public static readonly Random Random = new Random();
    }

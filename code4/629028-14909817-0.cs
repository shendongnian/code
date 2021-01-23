    class YourPositioningType {
        public int X { get; set; }
        public int Y { get; set; }
        public static YourPositioningType FromVector(Vector2 vector) {
            return new YourPositioningType() { X = vector.X, Y = vector.Y };
        }
        public static YourPositioningType FromRectangle(Rectangle rect) {
            // etc..
        }
    }

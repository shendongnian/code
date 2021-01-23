    public static class Extensions {
        public static Size Multiply(this Size size, double factor) {
            return new Size((int)(size.Width * factor), (int)(size.Height * factor));
        }
    }

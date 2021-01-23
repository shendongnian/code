    public static class LineExtensions {
        // returns the Line so you can use it fluently
        public static Line MakeLineBlack(this Line line) {
            line.Stroke = Brushes.Black;
            return line;
        }
    }

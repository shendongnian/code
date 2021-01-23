    class Visual 
    {
        public void Draw() 
        {
            using (new GraphicsPalette()) {
                DrawHeader();
                DrawFooter();
            }
        }
    
        private void DrawHeader() {
            var brush = GraphicsPalette.GetSolidBrush(Color.Green);
            ...   
        }
    
        public void DrawFooter() { 
            using (new GraphicsPalette()) { // ensures palette existence; does nothing if there is a palette on the stack
                var brush = GraphicsPalette.GetSolidBrush(Color.Green); // returns the same brush as in DrawHeader
                ...
            }
        }
    }

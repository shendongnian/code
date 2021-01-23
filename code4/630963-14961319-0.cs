    public static class LabelHelper
    {
        public static Label ChangeFormatting(this Label label, Font font, Color color, Color color)
        {
            if (label == null)
            {
                return;
            }
            
            label.Font = font;
            label.ForeColor = color;
        }
    }

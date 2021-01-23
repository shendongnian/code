    public static class TextBoxExtension
    {
        public static void Trim(this TextBox text){            
            string txt = text.Text;
            if (txt.Length == 0 || text.Width == 0) return;
            int i = txt.Length;            
            while (TextRenderer.MeasureText(txt + "...", text.Font).Width > text.Width)            
            {
                txt = text.Text.Substring(0, --i);
                if (i == 0) break;
            }
            text.Text = txt + "...";
        }
        //You can implement more methods such as receiving a string with font,... and returning the truncated/trimmed version.
     }

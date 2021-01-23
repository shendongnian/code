    public class Table {
    
        private readonly int? _width;
    
        public Table() {
            _width = null;
            // actually, we don't need to set _width to null
            // but to learning purposes we did.
        }
    
        public Table(int width) {
            _width = width;
        }
    
        public void Write(OurSampleHtmlWriter writer) {
            writer.Write("<table");
            // We have to check if our Nullable<T> variable has value, before using it:
            if(_width.HasValue)
                // if _width has value, we'll write it as a html attribute in table tag
                writer.WriteFormat(" style=\"width: {0}px;\">");
            else
                // otherwise, we just close the table tag
                writer.Write(">");
            writer.Write("</table>");
        }
    }

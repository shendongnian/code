    namespace iTextSharp.text {
        /// <summary>
        /// The PageSize-object contains a number of read only rectangles representing the most common paper sizes.
        /// </summary>
        /// <seealso cref="T:iTextSharp.text.RectangleReadOnly"/>
        public class PageSize {
            [...]
            /**
            * This method returns a Rectangle based on a String.
            * Possible values are the the names of a constant in this class
            * (for instance "A4", "LETTER",...) or a value like "595 842"
            */
            public static Rectangle GetRectangle(String name)  {
                [...]
            }
        }
    }

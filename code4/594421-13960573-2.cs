    public class SelectedColumns
    {
        //instead of the enum you would have boolean in the column type "Visible" (whether is shown or not)
        public enum renederingMode
        {
            Displayed,
            omitted
        }
        // instead of both these you would have a List o Column types that have a name AND a boolean, so you have your List<string> and a boolean to indicate whether it is visible or ommited. Well at least that's how I understood it.
        public class ommited
        {
    
        }
        public class displayed
        {
        }
    }

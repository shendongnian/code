    [Register ("LimitedTextView")]
    public class LimitedTextView : UITextView
    {
        public int MaxCharacters { get; set; }
        void Initialize ()
        {
            MaxCharacters = 140;
            ShouldChangeText = ShouldLimit;
        }
        static bool ShouldLimit (UITextView view, NSRange range, string text)
        {
            var textView = (LimitedTextView)view;
            var limit = textView.MaxCharacters;
            int newLength = (view.Text.Length - range.Length) + text.Length;
            if (newLength <= limit)
                return true;
            
            // This will clip pasted text to include as many characters as possible
            // See http://stackoverflow.com/a/5897912/458193
            
            var emptySpace = Math.Max (0, limit - (view.Text.Length - range.Length));
            var beforeCaret = view.Text.Substring (0, range.Location) + text.Substring (0, emptySpace);
            var afterCaret = view.Text.Substring (range.Location + range.Length);
            view.Text = beforeCaret + afterCaret;
            view.SelectedRange = new NSRange (beforeCaret.Length, 0);
            return false;
        }
        public LimitedTextView (IntPtr handle) : base (handle) { Initialize (); }
        public LimitedTextView (RectangleF frame) : base (frame) { Initialize (); }
    }

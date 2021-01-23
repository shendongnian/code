    public class PasswordEntryElement : EntryElement
    {
        static readonly NSString PasswordEntryElementCellKey = new NSString ("PasswordEntryElement");
        public PasswordEntryElement (string caption, string placeholder, string value) : base (caption, placeholder, value, true)
        {
        }
        protected override NSString CellKey {
            get { return PasswordEntryElementCellKey; }
        }
    }

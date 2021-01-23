    using System.Windows.Forms;
    // ...
    class WrappingLabel : Label
    {
        private bool _isWordWrap
        public bool IsWordWrap
        {
            get { return _isWordWrap; }
            set 
            {
                if( _isWordWrap != value )
                {
                    _isWordWrap = value;                    
                    FormatText( value );
                }
            }
        }
    
        private void FormatText( bool wrapped )
        {
            // logic to wrap or un-wrap text goes here.
            // you will need to call this when the text changes as well.
        }
    }

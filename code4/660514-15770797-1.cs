    namespace System.Windows.Controls
    {
        public class UnchangingCheckbox : CheckBox
        {
            public UnchangingCheckbox()
            {
                this.IsReadOnly = true;
            }
    
            public bool IsReadOnly 
            {
                get { return !this.IsHitTestVisible && !this.Focusable; }
                set 
                { 
                    this.IsHitTestVisible = !value; 
                    this.Focusable = !value;             
                }
            }
        }
    }

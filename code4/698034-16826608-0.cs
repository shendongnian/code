     public partial class MyDataGridView : DataGridView
        {
            private Form _curParent = null;
            protected override void OnInvalidated(InvalidateEventArgs e) 
            {
                //Exit if no parent, or _curParent already set.
                if (Parent == null || _curParent != null) return;
                
                base.OnInvalidated(e);
                
                //Recurse until parent form is found:
                Control parentForm = Parent;
                
                while (!(parentForm is Form))
                {
                    if (parentForm.Parent == null) return;  //Break if this is a null - indicates parent not yet created.
                    parentForm = parentForm.Parent; 
                }
                //Have now found parent form at the top of the ancestor tree.
                // be nice and remove the event from the old parent
                if (_curParent != null)
                {
                    _curParent.ResizeEnd -= MyDataGridView_ResizeEnd;
                }
                // now update _curParent to the new Parent
                _curParent = (Form)parentForm;
                
                //Add the resized event handler
                _curParent.ResizeEnd += MyDataGridView_ResizeEnd;
                
            }
            
            void MyDataGridView_ResizeEnd(object sender, EventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("Resize End called on parent. React now!");
            }
        }

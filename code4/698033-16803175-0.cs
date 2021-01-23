    public class CustomDataGridView : DataGridView
    {
        private Form _curParent;
        
        public CustomDataGridView()
        {
            // Since Parent is not set yet, handle the event that tells us that it *is* set
            this.ParentChanged += CustomDataGridView_ParentChanged;
        }
        void CustomDataGridView_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent is Form)
            {
                // be nice and remove the event from the old parent
                if (_curParent != null)
                {
                    _curParent.ResizeEnd -= CustomDataGridView_ResizeEnd;
                }
                // now update _curParent to the new Parent
                _curParent = (Form)this.Parent;
                _curParent.ResizeEnd += CustomDataGridView_ResizeEnd;
            }
        }
        void CustomDataGridView_ResizeEnd(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Resize End called on parent. React now!");
        }
    }

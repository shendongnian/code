    namespace System.Windows.Forms
    {
        class MyDataGridView : DataGridView
        {
            public bool PreventUserClick = false;
            public MyDataGridView()
            {
           
            }
            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (PreventUserClick) return;
            
                base.OnMouseDown(e);
            }
        }
    }

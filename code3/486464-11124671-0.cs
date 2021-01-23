    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    namespace MyControls
    {
    public class SelectedItemsGridView : DataGridView
    {
        private IList _SelectedItems;
        public IList SelectedItems 
        {
            get { return _SelectedItems; }
            set
            {
                _SelectedItems = value;
                ClearSelection();
                Refresh();
            }
        }
        public SelectedItemsGridView()
            : base()
        {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowHeadersVisible = false;
            VirtualMode = true;
            ////Columns.Add(new DataGridViewCheckBoxColumn(false) { 
            //    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
            //    HeaderText = "Select"});
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (DesignMode == true) { return; }
            Columns.Insert(0, new DataGridViewCheckBoxColumn(false)
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                HeaderText = "Select"
            });
        }
        public bool IsItemSelected(object obj)
        {
            if (SelectedItems == null) { return false; }
            return SelectedItems.Contains(obj);
        }
        protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
        {
            base.OnCellValueNeeded(e);
            if (e.ColumnIndex == 0)
            {
                e.Value = IsItemSelected((this.DataSource as IList)[e.RowIndex]);
            }
        }
        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            base.OnCellContentClick(e);
            if (e.RowIndex == -1) { return; }
            Object item = ((IList)DataSource)[e.RowIndex];
            if(e.ColumnIndex == 0)
            {
                var cellValue = this[e.ColumnIndex, e.RowIndex].Value;
                if (cellValue != null && (bool)cellValue == true)
                {
                    SelectedItems.Remove(item);
                    
                }
                else if (cellValue != null && (bool)cellValue == false)
                {
                    SelectedItems.Add(item);
                }
            }
        }
    }
}

    public partial class Form1 : XtraForm
    {
        int max = 2;
        public Form1()
        {
            InitializeComponent();
            InitGrid();
        }
        List<Person> gridDataList = new List<Person>();
        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridDataList.Add(new Person("John", "Forester"));
            gridDataList.Add(new Person("Gabriel", "Forester"));
            gridDataList.Add(new Person("Ashley", "Forester", "some comment"));
            gridDataList.Add(new Person("Adrian", "Forester", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Forester", "some comment"));
            bindingSource1.DataSource = gridDataList;
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int parentHandle = gridView1.GetParentRowHandle(e.RowHandle);
            int count = gridView1.GetChildRowCount(parentHandle);
            int childHandle = -1;
            int nCount = 0;
            for (int i = 0; i < count; i++)
            {
                childHandle = gridView1.GetChildRowHandle(parentHandle, i);
                Person p = gridView1.GetRow(childHandle) as Person;
                if (p != null)
                {
                    p.Blocked = false;
                    if (p.Selected)
                    {
                        nCount++;
                    }
                }
            }
            if (nCount == max)
            {
                for (int i = 0; i < count; i++)
                {
                    childHandle = gridView1.GetChildRowHandle(parentHandle, i);
                    Person p = gridView1.GetRow(childHandle) as Person;
                    if (p != null && !p.Selected)
                    {
                        p.Blocked = true;
                    }
                }
            }
            // to redraw grid
            gridView1.RefreshData();
        }
        private void richedSelected_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.PostEditor();
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            Person p = gridView1.GetRow(e.RowHandle) as Person;
            if (p != null && p.Blocked)
            {
                e.Appearance.ForeColor = Color.White;
            }
        }
        private void richedSelected_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Person p = gridView1.GetRow(gridView1.FocusedRowHandle) as Person;
            if (p != null && p.Blocked)
            {
                e.Cancel = true;
            }
        }
    }

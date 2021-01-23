    public partial class PanelForm : Form {
      public PanelForm() {
        InitializeComponent();
        int iHead = Controls.GetChildIndex(panelHead);
        int iData = Controls.GetChildIndex(panelData);
        int iFoot = Controls.GetChildIndex(panelFoot);
        if ((iHead < iData) || (iFoot < iData)) {
          panelHead.Dock = DockStyle.None;
          panelData.Dock = DockStyle.None;
          panelFoot.Dock = DockStyle.None;
          Controls.SetChildIndex(panelData, 0);
          Controls.SetChildIndex(panelHead, 1);
          Controls.SetChildIndex(panelFoot, 2);
          panelData.Dock = DockStyle.Fill;
          panelHead.Dock = DockStyle.Top;
          panelFoot.Dock = DockStyle.Bottom;
        }
        ShowData(DateTime.Now);
      }
      private void ShowData(DateTime now) {
        var table = new DataTable();
        var c1 = table.Columns.Add("Name", typeof(string));
        var c2 = table.Columns.Add("Even", typeof(bool));
        var c3 = table.Columns.Add("Index", typeof(int));
        var c4 = table.Columns.Add("Times 2", typeof(int));
        var c5 = table.Columns.Add("Inverse", typeof(double));
        var c6 = table.Columns.Add("Timespan", typeof(TimeSpan));
        var c7 = table.Columns.Add("Binary Time", typeof(long));
        var c8 = table.Columns.Add("Display", typeof(string));
        for (int i = 0; i < 1000; i++) {
          DataRow r = table.NewRow();
          r[c1] = string.Format("Row {0}", i);
          r[c2] = (i % 2 == 0);
          r[c3] = i;
          r[c4] = 2 * i;
          r[c5] = (0 < i) ? 1 / (double)i : double.NaN;
          r[c6] = DateTime.Now - now;
          r[c7] = DateTime.Now.ToBinary();
          r[c8] = string.Format("{0:g}", DateTime.Now);
          table.Rows.Add(r);
        }
        dataGridView1.DataSource = table;
      }
    }

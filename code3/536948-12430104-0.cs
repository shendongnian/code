    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                InitializeComboBox();
            }
    
            private ComboxBoxEx cbox1 = new ComboxBoxEx();
            private DataTable items = new DataTable();
    
            private void InitializeComboBox()
            {
                items.Columns.AddRange(new DataColumn[] { new DataColumn("id"), new DataColumn("name"), new DataColumn("address") });
    
                items.Rows.Add(new object[] { 0, "[Please choose an address]", "" });
                items.Rows.Add(new object[] { 1, "Country", "Country" });
                items.Rows.Add(new object[] { 2, "House name", "House name\nStreet name\nTown name\nPostcode\nCountry" });
                items.Rows.Add(new object[] { 3, "House name", "House name\nStreet name\nTown name\nPostcode\nCountry" });
    
                cbox1.Location = new Point(39, 20);
                cbox1.Size = new System.Drawing.Size(198, 21);
                cbox1.DrawMode = DrawMode.OwnerDrawVariable;
                cbox1.DrawItem += new DrawItemEventHandler(comboBox2_DrawItem);
                cbox1.MeasureItem += new MeasureItemEventHandler(comboBox2_MeasureItem);
                cbox1.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
                //cbox1.DropDownWidth = 250;
                cbox1.DropDownHeight = 300;
                //cbox1.MaxDropDownItems = 6;
                this.Controls.Add(cbox1);
    
                cbox1.ValueMember = "id";
                cbox1.DisplayMember = "name";
                cbox1.DataSource = new BindingSource(items, null);
                //cbox1.SelectedIndex = -1;
            }
        
            private void comboBox2_MeasureItem(object sender, MeasureItemEventArgs e)
            {
                ComboxBoxEx cbox = (ComboxBoxEx)sender;
                DataRowView item = (DataRowView)cbox.Items[e.Index];
                string txt = item["address"].ToString();
    
                int height = Convert.ToInt32(e.Graphics.MeasureString(txt, cbox.Font).Height);
    
                e.ItemHeight = height + 4;
                e.ItemWidth = cbox.DropDownWidth;
    
                cbox.ItemHeights.Add(e.ItemHeight);
            }
    
            private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
            {
                ComboxBoxEx cbox = (ComboxBoxEx)sender;
                DataRowView item = (DataRowView)cbox.Items[e.Index];
                string txt = item["address"].ToString();
    
                e.DrawBackground();
                e.Graphics.DrawString(txt, cbox.Font, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.DrawLine(new Pen(Color.LightGray), e.Bounds.X, e.Bounds.Top + e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Top + e.Bounds.Height - 1);
                e.DrawFocusRectangle();
            }
    
            private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                ComboxBoxEx cbox = (ComboxBoxEx)sender;
                if (cbox.SelectedItem == null) return;
    
                DataRowView item = (DataRowView)cbox.SelectedItem;
                //label1.Text = item["id"].ToString();
            }
        }
    }

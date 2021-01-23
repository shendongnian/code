    class testToolTip
            {
                public string P1
                {
                    get;
                    set;
                }
                public string p2
                {
                    get;
                    set;  
                }
            }
            ToolTip toolTip = new ToolTip();    
            public Form1()
            {
                InitializeComponent();
                List<testToolTip> lstToolTip = new List<testToolTip>();
                for (int i = 0; i < 100; i++)
                {
                    testToolTip  t =    new testToolTip()  ;  
                    t.P1 =   "Prop " + i.ToString();  
                    t.p2  =  "Prop 1" + i.ToString();
                    lstToolTip.Add(t);                
                }
                dataGridView1.DataSource = lstToolTip;
                toolTip.IsBalloon = true;
                toolTip.UseAnimation = true;
                toolTip.UseFading = true;   
               
            }
    
            private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
            {
                
                Rectangle rect = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                
                toolTip.Show(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), this, rect.Location.X, rect.Location.Y,1000);
    
    
            }

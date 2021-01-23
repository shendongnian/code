        GraphPane pane;
        public Form1()
        {
            InitializeComponent();
            pane = zedGraphControl1.GraphPane;            
        }
        private void button_AddTxtObj_Click(object sender, EventArgs e)
        {            
            TextObj textEquation = new TextObj("Add your Text", pane.XAxis.Scale.Min+ (3*(pane.XAxis.Scale.MinorStep)), pane.YAxis.Scale.Max-pane.YAxis.Scale.MinorStep);            
            pane.GraphObjList.Add(textEquation);
            zedGraphControl1.Refresh();
        }
        private void button_ClearTxtObj_Click(object sender, EventArgs e)
        {
            pane.GraphObjList.Clear();
            zedGraphControl1.Refresh();
        }

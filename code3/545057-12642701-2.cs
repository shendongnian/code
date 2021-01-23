     public partial class Form1 : Form
    {
        List<Int32> Children;
        public Form1()
        {
            InitializeComponent();
            Children = new List<int>();
            Children.AddRange(Enumerable.Range(0, 20));
            ShowChildren();
        }
        private void ShowChildren()
        {
            for (int i = 0; i < Children.Count; i += 3)
            {
                AddRow(i, Children);
            }
        }
        private void AddRow(int startIndex, List<Int32> Nodes)
        {
            int NodesOnThisRow = 3;
            if (Nodes.Count - startIndex < 3)
                NodesOnThisRow = Nodes.Count - startIndex;
            Panel newPanel = new Panel();
            newPanel.Height = 25;
            int x = 8;
            for (int i = 0; i < NodesOnThisRow; i++)
            {
                Label L = new Label();
                TextBox T = new TextBox();
                //You could dock these left so they just appear one after the other, or since there
                //is only 3 you could just hard code the 3 x values, or calc them
                L.Left = x;
                T.Left = x + 120;
                L.Text = Nodes[startIndex + i].ToString();
                T.Text = Nodes[startIndex + i].ToString();
                x += 250;
                newPanel.Controls.Add(L);
                newPanel.Controls.Add(T);
            }
            groupBox1.Controls.Add(newPanel);
            newPanel.Dock = DockStyle.Top;
            newPanel.BringToFront();
        }
    }

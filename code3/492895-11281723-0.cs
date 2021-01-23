    private void Form4_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("LaptopsNodeKey", "Laptop");
            treeView1.Nodes.Add("CellPhonesNodeKey", "Phones");
            treeView1.Nodes.Find("LaptopsNodeKey", true)[0].Nodes.Add("DellTM", "Dell");
            treeView1.Nodes.Find("LaptopsNodeKey", true)[0].Nodes.Add("SonyTM", "Sony");
            treeView1.Nodes.Find("CellPhonesNodeKey", true)[0].Nodes.Add("HTCTM", "HTC");
            treeView1.Nodes.Find("CellPhonesNodeKey", true)[0].Nodes.Add("NokiaTM", "Nokia");
            comboBox1.Items.Add("LaptopsNodeKey");
            comboBox1.Items.Add("CellPhonesNodeKey");
            comboBox2.Items.Add("Laptop");
            comboBox2.Items.Add("Phones");
        }
        
        //This works because you Loaded ComboBox1 with Name property of Nodes
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
            treeView1.SelectedNode = treeView1.Nodes.Find(comboBox1.Text, true)[0];
            treeView1.SelectedNode.Expand();
        }
        //This doesn't work, because you Loaded ComboBox2 with Text property of Nodes
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
            treeView1.SelectedNode = treeView1.Nodes.Find(comboBox1.Text, true)[0];
            treeView1.SelectedNode.Expand();
        }

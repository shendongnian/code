    private void Form1_Load(object sender, EventArgs e)
    {
        AutoCompleteStringCollection suggestStageName = new AutoCompleteStringCollection();
        foreach (TreeNode subNode in treeNode.Nodes)
        {
            suggestStageName.Add(subNode.Name);
        }
        textBox1.AutoCompleteCustomSource = suggestStageName;
        textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

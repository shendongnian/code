    private void ChildNode_Click(object sender, RoutedEventArgs args)
    {
        System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
        Node node = Part.FindAncestor<Node>(button);
        MyNodeData nodeData = node.Data as MyNodeData;
        foreach (TabItem item in tabControl.Items)
        {
            if (nodeData.Text == item.Header.ToString())
            {
                item.Focus();
            }
            else if (nodeData.Text != item.Header.ToString())
            {
                // This line will throw an exception 
                DoSomethingThatModifiesTabControlItemsCollection()
            }
        }
     }

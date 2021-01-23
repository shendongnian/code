    private List<string> SelectedNodes = new List<string>();
    private void GetSelectedNodeText(NodeCollection nodes)
    {
        foreach (Node node in nodes)
        {
            if (node.IsChecked != true && node.IsChecked != false)
            {
                SelectedNodes.Add(node.Text + "_" + GetSelectedChildNodeText(node.ChildNodes));
            }
            else if (node.IsChecked == true)
            {
                SelectedNodes.Add(node.Text);
            }
        }
    }
    private string GetSelectedChildNodeText(NodeCollection nodes)
    {
        string retValue = string.Empty;
        foreach (Node node in nodes)
        {
            if (node.IsChecked != true && node.IsChecked != false)
            {
                retValue = node.Text + "_" + GetSelectedChildNodeText(node.ChildNodes);
            }
            else if (node.IsChecked == true)
            {
                retValue = node.Text;
            }
        }
        return retVal;
    }

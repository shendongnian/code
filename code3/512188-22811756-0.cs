    private void tree_ShowingEditor(object sender, CancelEventArgs e)
        {
            Nodes.PromptNode promptNode = tree.FocusedNode as Nodes.PromptNode;
            if (tree.FocusedColumn == valueColumn && promptNode.PromptResult.ValueType.MyValueType == ValueType.ValueTypeOptions.Calculated)
            {
                e.Cancel = true;
            }
        }

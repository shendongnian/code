    <TreeView SelectedItemChanged="TreeView_SelectedItemChanged"
              GotFocus="UIElement_OnGotFocus">
       <TreeViewItem>
          <TreeViewItem.Header>
              <TextBox>Textbox Header</TextBox>
           </TreeViewItem.Header>
       </TreeViewItem>
       <TreeViewItem>
            <TreeViewItem.Header>String Header</TreeViewItem.Header>
       </TreeViewItem>
     </TreeView>
	private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
	{
		TreeViewItem item = UIHelpers.TryFindParent<TreeViewItem>   
                               ((DependencyObject) e.OriginalSource);
		if (item != null)
              item.IsSelected = true;
	}

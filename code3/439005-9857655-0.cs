    <TreeView SelectedItemChanged="TreeView_SelectedItemChanged">
       <TreeViewItem>
          <TreeViewItem.Header>
              <TextBox GotFocus="UIElement_OnGotFocus">Textbox Header</TextBox>
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
		item.IsSelected = true;
	}

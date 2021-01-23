    public static class ListBoxExtension
    {
    	public static void RemoveSelectedItems(this ListBox source)
    	{
    		if(source==null) return;
      		while(source.SelectedItems.Count!=0)
    		{
    			source.Items.Remove(source.SelectedItems[0]);
    		}
    	}
    }

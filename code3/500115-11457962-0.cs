    class Comparer : IComparer<ListViewItem> 
    {   	
        public int Compare (ListViewItem left, ListViewItem right)
    	{
    		var leftGroup = DetermineGroup(left);
    		var rightGroup = DetermineGroup(right);
    	
    		if(leftGroup == rightGroup) 
            { 
               return left.Text.CompareTo(right.Text);
            }
    	
    		return leftGroup.CompareTo(rightGroup);
    	}
        enum Grouping 
        {
    		RedBack,
    		RedFront,
    		Neither
    	}
    
    	Grouping DetermineGroup(ListViewItem x) 
    	{
    		if(x.BackColor == Color.Red) return Grouping.RedBack;
    		if(x.ForeColor == Color.Red) return Grouping.RedFront;
    		
    		return Grouping.Neither;
    	}
    }

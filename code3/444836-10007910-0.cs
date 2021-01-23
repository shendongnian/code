    List<int> _list1 = new List<int>(); //1, 2, 3, 4, 5
	
    foreach (var item in _list1)
    {
        // take copy of loop variable to avoid closing over the loop variable
        int i = item; 
        Label lb = new Label { Text = item.ToString() };
        lb.Click += (x,y) => CustomFunction(i);
    }
    void CustomFunction(int item)
    {
    }

    //datagridview1 is bound to this BindingList 
    BindingList<myObject> object_bound_list1;
    
    //datagridview2 is bound to this BindingList 
    BindingList<myObject> object_bound_list2;
    
    List<myObject> selected_Object_list = new List<myObject>();
    List<int> selected_pos_list = new List<int>();
    
    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
    {
    	if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
    	{
    		// Proceed with the drag and drop, passing in the list item.                   
    		DragDropEffects dropEffect = dataGridView1.DoDragDrop(
    		selected_Object_list,
    		DragDropEffects.Move);
    	}
    }
    
    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
    	// Get the index of the item the mouse is below.
    	int rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
    
    	//if shift key is not pressed
    	if (Control.ModifierKeys != Keys.Shift && Control.ModifierKeys != Keys.Control)
    	{
    		//if row under the mouse is not selected
    		if (!selected_pos_list.Contains(rowIndexFromMouseDown) && rowIndexFromMouseDown > 0)
    		{
    		//if there only one row selected
    			if (dataGridView1.SelectedRows.Count == 1)
    			{
                    //select the row below the mouse
    				dataGridView.ClearSelection();
    				dataGridView1.Rows[rowIndexFromMouseDown].Selected = true;
    			}
    		}
    	}
    
    	//clear the selection lists
    	selected_Object_list.Clear();
    	selected_pos_list.Clear();
    
    	//add the selected objects
    	foreach (DataGridViewRow row in dataGridView1.SelectedRows)
    	{
    		selected_Object_list.Add(object_bound_list1[row.Index]);
    		selected_pos_list.Add(row.Index);
    	}
    }
    
    private void dataGridView2_DragOver(object sender, DragEventArgs e)
    {
    	e.Effect = DragDropEffects.Move;
    }
    
    private void dataGridView2_DragDrop(object sender, DragEventArgs e)
    {
    	if (e.Effect == DragDropEffects.Move)
    	{
    		foreach (var item in selected_Object_list)
    		{
    			object_bound_list2.Add(item);
    		}
    	}
    }

    public class DataGrid : System.Windows.Controls.DataGrid
    {
    	private void PressKey(Key key)
    	{
    		KeyEventArgs args = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key);
    		args.RoutedEvent = Keyboard.KeyDownEvent;
    		InputManager.Current.ProcessInput(args);
    	}
    	protected override void OnCurrentCellChanged(EventArgs e)
    	{
    		if (this.CurrentCell.Column != null)                
    			if (this.CurrentCell.Column.DisplayIndex == 2)
    			{
    
    				if (this.CurrentCell.Item.ToString() == "--End Of List--")
    				{
    					this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
    				}
    			}
    			else if (this.CurrentCell.Column != null && this.CurrentCell.Column.DisplayIndex == this.Columns.Count() - 1)
    			{
    				PressKey(Key.Return);
    				DataGridCell cell = DataGridHelper.GetCell(this.CurrentCell);
    				int index = DataGridHelper.GetRowIndex(cell);
    				DataGridRow dgrow = (DataGridRow)this.ItemContainerGenerator.ContainerFromItem(this.Items[index]);
    				dgrow.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    			}
    	}
    	protected override void OnKeyDown(KeyEventArgs e)
    	{
    		if (e.Key == Key.Enter)
    		{
    			DataGridRow rowContainer = (DataGridRow)this.ItemContainerGenerator.ContainerFromItem(this.CurrentItem);
    			if (rowContainer != null)
    			{
    				int columnIndex = this.Columns.IndexOf(this.CurrentColumn);
    				DataGridCellsPresenter presenter = UIHelper.GetVisualChild<DataGridCellsPresenter>(rowContainer);
    				if (columnIndex == 0)
    				{
    					DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
    					TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
    					request.Wrapped = true;
    					cell.MoveFocus(request);
    					BeginEdit();
    					PressKey(Key.Down);
    				}
    				else
    				{
    					CommitEdit();
    					DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
    					TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);
    					request.Wrapped = true;
    					cell.MoveFocus(request);
    				}
    				this.SelectedItem = this.CurrentItem;
    				e.Handled = true;
    				this.UpdateLayout();
    			}
    		}
    	}
    }

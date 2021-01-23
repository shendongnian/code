    void Main()
    {
    	new MyForm().Show();
    }
    
    public class MyForm : Form
    {
    	public MyForm()
    	{
    		var grid = new GridControl();
    		var gridview = new DevExpress.XtraGrid.Views.Grid.GridView(grid);
    		var button = new Button { Enabled = false, Text = "Next", Dock= DockStyle.Bottom };
    		
    		gridview.TopRowChanged += (o, e) => 
    		{
    			int bottomRowIndex = gridview.TopRowIndex + ((GridViewInfo)gridview.GetViewInfo()).RowsInfo.Count;
    			if (bottomRowIndex == gridview.RowCount)
    			{
    				button.Enabled = true;
    			}
    		};
    		
    		grid.MainView = gridview;
    		grid.DataSource = new [] {9,8,7,6,5,4,3,2,1};
    	
    		Controls.Add(grid);
    		Controls.Add(button);
    	}
    }

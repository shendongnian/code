    using System.Drawing;
    using System.Windows.Forms;
    using System;
    
    public class DataGridViewBandDemo : Form
    {
    	#region "form setup"
    	public DataGridViewBandDemo()
    	{
    		InitializeComponent();
    		InitializeDataGridView();
    	}
    
    	DataGridView dataGridView;
    	FlowLayoutPanel FlowLayoutPanel1 = new FlowLayoutPanel();
    
    	private void InitializeComponent()
    	{
    		FlowLayoutPanel1.Location = new Point(454, 0);
    		FlowLayoutPanel1.AutoSize = true;
    		FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
    		AutoSize = true;
    		ClientSize = new System.Drawing.Size(614, 360);
    		FlowLayoutPanel1.Name = "flowlayoutpanel";
    		Controls.Add(this.FlowLayoutPanel1);
    		Text = this.GetType().Name;
    	}
    	#endregion
    
    	#region "setup DataGridView"
    
    	private void InitializeDataGridView()
    	{
    		dataGridView = new System.Windows.Forms.DataGridView();
    		Controls.Add(dataGridView);
    		dataGridView.Size = new Size(300, 200);
    
    		// Create an unbound DataGridView by declaring a
    		// column count.
    		dataGridView.ColumnCount = 4;
    
    		// Set the column header style.
    		DataGridViewCellStyle columnHeaderStyle =
    			new DataGridViewCellStyle();
    		columnHeaderStyle.BackColor = Color.Aqua;
    		columnHeaderStyle.Font =
    			new Font("Verdana", 10, FontStyle.Bold);
    		dataGridView.ColumnHeadersDefaultCellStyle =
    			columnHeaderStyle;
    
    		// Set the column header names.
    		dataGridView.Columns[0].Name = "Recipe";
    		dataGridView.Columns[1].Name = "Category";
    		dataGridView.Columns[2].Name = "Whatever";
    		dataGridView.Columns[3].Name = "Rating";
    
    		// Populate the rows.
    		string[] row1 = new string[]{"Meatloaf", 
                                            "Main Dish", "boringMeatloaf", "boringMeatloafRanking"};
    		string[] row2 = new string[]{"Key Lime Pie", 
                                            "Dessert", "lime juice, evaporated milk", "****"};
    		string[] row3 = new string[]{"Orange-Salsa Pork Chops", 
                                            "Main Dish", "pork chops, salsa, orange juice", "****"};
    		string[] row4 = new string[]{"Black Bean and Rice Salad", 
                                            "Salad", "black beans, brown rice", "****"};
    		string[] row5 = new string[]{"Chocolate Cheesecake", 
                                            "Dessert", "cream cheese", "***"};
    		string[] row6 = new string[]{"Black Bean Dip", "Appetizer",
                                            "black beans, sour cream", "***"};
    		string[] row7 = new string[]{"Black Bean Dip", "Appetizer",
                                            "black beans, sour cream", "***"};
    		string[] row8 = new string[]{"Jelly beans", "Appetizer",
                                            "black beans, sour cream", "***"};
    		string[] row9 = new string[]{"Barracuda", "Appetizer",
                                            "black beans, sour cream", "***"};
    		object[] rows = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9 };
    
    		foreach (string[] rowArray in rows)
    		{
    			dataGridView.Rows.Add(rowArray);
    		}
    
                dataGridView.ColumnHeadersVisible = false; // This hides regular column header
    		FreezeFirstRow();
    		// FreezeFirstColumn(); // Uncomment this line to freeze first column
    
    	}
    
    	// Freeze the first row.
    	private void FreezeFirstRow()
    	{
    		FreezeBand(dataGridView.Rows[0]);
    	}
    
    	private void FreezeFirstColumn()
    	{
    		FreezeBand(dataGridView.Columns[1]);
    	}
    
    	private static void FreezeBand(DataGridViewBand band)
    	{
    		band.Frozen = true;
    		DataGridViewCellStyle style = new DataGridViewCellStyle();
    		style.BackColor = Color.WhiteSmoke;
    		band.DefaultCellStyle = style;
    	}
    
    	#endregion
    
    	[STAThreadAttribute()]
    	public static void Main()
    	{
    		Application.Run(new DataGridViewBandDemo());
    	}
    }

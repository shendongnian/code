    using System;
    using System.Data;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
    	DataGridView dgv;
    	CheckBox hideCloseCheckBox;
    	BindingSource bindingSource;
    
    	public Form1()
    	{
    		/*
    		 * Add a DataGridView with a simulated DataSet
    		 * 
    		 * Note that we add a BindingSource between the DataSource member of the DGV and the DataSet.
    		 * We will use that BindingSource to filter the items.
    		 */
    		Controls.Add((dgv = new DataGridView
    		{
    			Dock = DockStyle.Fill,
    
    			AutoGenerateColumns = false,
    			Columns =
    			{
    				new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", HeaderText = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
    				new DataGridViewCheckBoxColumn { Name = "Open", DataPropertyName = "Open", HeaderText = "Open", AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader },
    			},
    
    			DataSource = (bindingSource = new BindingSource(new DataSet
    			{
    				Tables =
    				{
    					new DataTable("Table1")
    					{
    						Columns =
    						{
    							new DataColumn("Name", typeof(string)),
    							new DataColumn("Open", typeof(bool)),
    						},
    
    						Rows =
    						{
    							{ "Item 1", true },
    							{ "Item 2", false },
    							{ "Item 3", true },
    							{ "Item 4", false },
    							{ "Item 5", true },
    						},
    					},
    				},
    			}, "Table1")),
    		}));
    
    		/*
    		 * Add a "Hide closed records" checkbox
    		 */
    		Controls.Add((hideCloseCheckBox = new CheckBox
    		{
    			Dock = DockStyle.Top,
    			Text = "Hide closed records",
    			Padding = new Padding(20, 0, 0, 0),
    		}));
    
    		/*
    		 * When the user clicks that checkbox, we change the Filter on the BindingSource
    		 * 
    		 * See http://msdn.microsoft.com/en-us/library/cabd21yw.aspx for details on filter expressions.
    		 */
    		hideCloseCheckBox.Click += (s, e) =>
    			{
    				if (hideCloseCheckBox.Checked)
    					bindingSource.Filter = "Open = true";
    				else
    					bindingSource.Filter = "";
    			};
    
    		/*
    		 * The problem we have now is that when the user toggles the Open checkbox, the record doesn't
    		 * dissappear from view when the filter is enabled. This is because triggering the checkbox
    		 * doesn't change the row data until after the row is committed. This normally happens when
    		 * the user leaves the row. If you're allowing other editing on the row, this may be the 
    		 * desired behavior as you don't want the row to vanish mid-edit. However, if you do, you
    		 * can force the issue by causing a checkbox toggle to commit the row.
    		 */
    		dgv.CellContentClick += (s, e) =>
    			{
    				// If the "Open" column is clicked
    				if (dgv.Columns[e.ColumnIndex].Name == "Open")
    				{
    					// Trigger EndEdit on the dgv and if that succeeds, trigger it on the bindingSource
    					if (dgv.EndEdit())
    						bindingSource.EndEdit();
    				}
    			};
    	}
    
    	[STAThread]
    	static void Main()
    	{
    		Application.EnableVisualStyles();
    		Application.SetCompatibleTextRenderingDefault(false);
    		Application.Run(new Form1());
    	}
    }

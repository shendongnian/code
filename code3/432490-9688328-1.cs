    private void button1_Click(object sender, System.EventArgs e)
    {
    	Excel.Application oXL;
    	Excel._Workbook oWB;
    	Excel._Worksheet oSheet;
    	Excel.Range oRng;
    
    	try
    	{
    		//Start Excel and get Application object.
    		oXL = new Excel.Application();
    		oXL.Visible = true;
    
    		//Get a new workbook.
    		oWB = (Excel._Workbook)(oXL.Workbooks.Add( Missing.Value ));
    		oSheet = (Excel._Worksheet)oWB.ActiveSheet;
    
    		//Add table headers going cell by cell.
    		oSheet.Cells[1, 1] = "First Name";
    		oSheet.Cells[1, 2] = "Last Name";
    		oSheet.Cells[1, 3] = "Full Name";
    		oSheet.Cells[1, 4] = "Salary";
    
    		//Format A1:D1 as bold, vertical alignment = center.
    		oSheet.get_Range("A1", "D1").Font.Bold = true;
    		oSheet.get_Range("A1", "D1").VerticalAlignment = 
    			Excel.XlVAlign.xlVAlignCenter;
    		
    		// Create an array to multiple values at once.
    		string[,] saNames = new string[5,2];
    		
    		saNames[ 0, 0] = "John";
    		saNames[ 0, 1] = "Smith";
    		saNames[ 1, 0] = "Tom";
    		saNames[ 1, 1] = "Brown";
    		saNames[ 2, 0] = "Sue";
    		saNames[ 2, 1] = "Thomas";
    		saNames[ 3, 0] = "Jane";
    		saNames[ 3, 1] = "Jones";
    		saNames[ 4, 0] = "Adam";
    		saNames[ 4, 1] = "Johnson";
    
            	//Fill A2:B6 with an array of values (First and Last Names).
    	        oSheet.get_Range("A2", "B6").Value2 = saNames;
    
    		//Fill C2:C6 with a relative formula (=A2 & " " & B2).
    		oRng = oSheet.get_Range("C2", "C6");
    		oRng.Formula = "=A2 & \" \" & B2";
    
    		//Fill D2:D6 with a formula(=RAND()*100000) and apply format.
    		oRng = oSheet.get_Range("D2", "D6");
    		oRng.Formula = "=RAND()*100000";
    		oRng.NumberFormat = "$0.00";
    
    		//AutoFit columns A:D.
    		oRng = oSheet.get_Range("A1", "D1");
    		oRng.EntireColumn.AutoFit();
    
    		//Manipulate a variable number of columns for Quarterly Sales Data.
    		DisplayQuarterlySales(oSheet);
    
    		//Make sure Excel is visible and give the user control
    		//of Microsoft Excel's lifetime.
    		oXL.Visible = true;
    		oXL.UserControl = true;
    	}
    	catch( Exception theException ) 
    	{
    		String errorMessage;
    		errorMessage = "Error: ";
    		errorMessage = String.Concat( errorMessage, theException.Message );
    		errorMessage = String.Concat( errorMessage, " Line: " );
    		errorMessage = String.Concat( errorMessage, theException.Source );
    
    		MessageBox.Show( errorMessage, "Error" );
    	}
    }
    
    private void DisplayQuarterlySales(Excel._Worksheet oWS)
    {
    	Excel._Workbook oWB;
    	Excel.Series oSeries;
    	Excel.Range oResizeRange;
    	Excel._Chart oChart;
    	String sMsg;
    	int iNumQtrs;
    
    	//Determine how many quarters to display data for.
    	for( iNumQtrs = 4; iNumQtrs >= 2; iNumQtrs--)
    	{
    		sMsg = "Enter sales data for ";
    		sMsg = String.Concat( sMsg, iNumQtrs );
    		sMsg = String.Concat( sMsg, " quarter(s)?");
    
    		DialogResult iRet = MessageBox.Show( sMsg, "Quarterly Sales?", 
    			MessageBoxButtons.YesNo );
    		if (iRet == DialogResult.Yes)
    			break;
    	}
    
    	sMsg = "Displaying data for ";
    	sMsg = String.Concat( sMsg, iNumQtrs );
    	sMsg = String.Concat( sMsg, " quarter(s)." );
    
    	MessageBox.Show( sMsg, "Quarterly Sales" );
    
    	//Starting at E1, fill headers for the number of columns selected.
    	oResizeRange = oWS.get_Range("E1", "E1").get_Resize( Missing.Value, iNumQtrs);
    	oResizeRange.Formula = "=\"Q\" & COLUMN()-4 & CHAR(10) & \"Sales\"";
    
    	//Change the Orientation and WrapText properties for the headers.
    	oResizeRange.Orientation = 38;
    	oResizeRange.WrapText = true;
    
    	//Fill the interior color of the headers.
    	oResizeRange.Interior.ColorIndex = 36;
    
    	//Fill the columns with a formula and apply a number format.
    	oResizeRange = oWS.get_Range("E2", "E6").get_Resize( Missing.Value, iNumQtrs);
    	oResizeRange.Formula = "=RAND()*100";
    	oResizeRange.NumberFormat = "$0.00";
    
    	//Apply borders to the Sales data and headers.
    	oResizeRange = oWS.get_Range("E1", "E6").get_Resize( Missing.Value, iNumQtrs);
    	oResizeRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
    
    	//Add a Totals formula for the sales data and apply a border.
    	oResizeRange = oWS.get_Range("E8", "E8").get_Resize( Missing.Value, iNumQtrs);
    	oResizeRange.Formula = "=SUM(E2:E6)";
    	oResizeRange.Borders.get_Item( Excel.XlBordersIndex.xlEdgeBottom ).LineStyle 
    		= Excel.XlLineStyle.xlDouble;
    	oResizeRange.Borders.get_Item( Excel.XlBordersIndex.xlEdgeBottom ).Weight 
    		= Excel.XlBorderWeight.xlThick;
    
    	//Add a Chart for the selected data.
    	oWB = (Excel._Workbook)oWS.Parent;
    	oChart = (Excel._Chart)oWB.Charts.Add( Missing.Value, Missing.Value, 
    		Missing.Value, Missing.Value );
    
    	//Use the ChartWizard to create a new chart from the selected data.
    	oResizeRange = oWS.get_Range("E2:E6", Missing.Value ).get_Resize( 
    		Missing.Value, iNumQtrs);
    	oChart.ChartWizard( oResizeRange, Excel.XlChartType.xl3DColumn, Missing.Value,
    		Excel.XlRowCol.xlColumns, Missing.Value, Missing.Value, Missing.Value, 
    		Missing.Value, Missing.Value, Missing.Value, Missing.Value );
    	oSeries = (Excel.Series)oChart.SeriesCollection(1);
    	oSeries.XValues = oWS.get_Range("A2", "A6");
    	for( int iRet = 1; iRet <= iNumQtrs; iRet++)
    	{
    		oSeries = (Excel.Series)oChart.SeriesCollection(iRet);
    		String seriesName;
    		seriesName = "=\"Q";
    		seriesName = String.Concat( seriesName, iRet );
    		seriesName = String.Concat( seriesName, "\"" );
    		oSeries.Name = seriesName;
    	}														  
    	
    	oChart.Location( Excel.XlChartLocation.xlLocationAsObject, oWS.Name );
    
    	//Move the chart so as not to cover your data.
    	oResizeRange = (Excel.Range)oWS.Rows.get_Item(10, Missing.Value );
    	oWS.Shapes.Item("Chart 1").Top = (float)(double)oResizeRange.Top;
    	oResizeRange = (Excel.Range)oWS.Columns.get_Item(2, Missing.Value );
    	oWS.Shapes.Item("Chart 1").Left = (float)(double)oResizeRange.Left;
    }
    	

    using XLS = Microsoft.Office.Interop.Excel;
    object[,] arrWks;
    object objKom;
    string strKom;
    
    arrWks = (object[,])sheet.UsedRange.get_Value(XLS.XlRangeValueDataType.xlRangeValueDefault);
    
    for (int intRow=arrWks.GetLowerBound(0); intRow<=arrWks.GetUpperBound(0); intRow++)
    {
    	for (int intCol=arrWks.GetLowerBound(1); intCol<=arrWks.GetUpperBound(1); intCol++)
    	{
    		objKom = arrWks[intRow, intCol];
    		strKom = objKom == null ? "" : objKom.ToString();		
    		
    		//do rest of your logic here
    	}
    }

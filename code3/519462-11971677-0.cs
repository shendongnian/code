    Microsoft.Office.Interop.Excel.Application myExcel;
    this.Activate ( );
    myExcel = ( Microsoft.Office.Interop.Excel.Application ) System.Runtime.InteropServices.Marshal.GetActiveObject ( "Excel.Application" )
    MessageBox.Show ( myExcel.ActiveWorkbook.FullName ); // gives full path
    MessageBox.Show ( myExcel.ActiveWorkbook.Name ); // gives file name

    string printername = "...";
    var wordapp = new Microsoft.Office.Interop.Word.Application();
    if (wordapp != null)
    {
	    object[] argValues = new object[2];
	    argValues[0] = printername;
	    argValues[1] = 1;
	    string[] argNames = new string[2];
	    argNames[0] = "Printer";
	    argNames[1] = "DoNotSetAsSysDefault";
	    var wb = wordapp.WordBasic;
	    wb.GetType().InvokeMember("FilePrintSetup", System.Reflection.BindingFlags.InvokeMethod, null, wb, argValues, null, null, argNames);
    }

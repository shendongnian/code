	private int PrintBarcode(string barcode, string printFormat, int printCount)
		{
			string text = "B400,50,1,1,2,1,150,B,";
			if (printFormat != null)
			{
				text = printFormat;
			}
			string barcod = string.Concat(new object[]
			{
				text,
				Convert.ToChar(34),
				barcode,
				Convert.ToChar(34),
				"\n"
			});
            string printerName= ConfigurationManager.AppSettings["PrinterName"];
            int x = 100;
            int y = 0;
            using (EtiquetaTestCommand1 etiquetaTestCommand = new EtiquetaTestCommand1(new Size(500, 750), 19, new Point(x, y), printCount, barcod))
            {
                string commandString = ((ICommand)etiquetaTestCommand).GetCommandString();
              
                
                //var sb1 = new StringBuilder();
               // sb1.AppendLine();
               // sb1.AppendLine("N");
               // sb1.AppendLine("Q750,19");
               // sb1.AppendLine("q500");
               // sb1.AppendLine("R100,0");
               // sb1.AppendLine(barcod);
               // sb1.AppendLine("P1");
                RawPrinterHelper.SendStringToPrinter(printerName, commandString.ToString());
                
            }

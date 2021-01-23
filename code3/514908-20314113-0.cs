		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Reflection;
		using Microsoft.Office.Interop.Excel;
		using Microsoft.Office.Interop;
		using System.IO;
		namespace SaveXmlAsExcel
		{
			class Program
			{
				static void Main(string[] args)
				{
					string xml  = args[0];
					string xlsx = args[1];
					if (false == File.Exists(xml))
					{
						Console.WriteLine("{0} file not exist", xlsx);
						return;
					}
				
					Microsoft.Office.Interop.Excel.Application xApp = new Microsoft.Office.Interop.Excel.Application();
					Microsoft.Office.Interop.Excel.Workbook excelWorkBook = xApp.Workbooks.OpenXML(xml, Type.Missing, Microsoft.Office.Interop.Excel.XlXmlLoadOption.xlXmlLoadImportToList);
					excelWorkBook.SaveAs(xlsx, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
					excelWorkBook.Close();
					xApp.Workbooks.Close();
				}
			}
		}

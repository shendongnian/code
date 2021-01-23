    using System;
    using Microsoft.Office.Interop.Word;
    
    namespace PageSetup
    {
    	class TestPageOrientation
    	{
    		static void Main(string[] args)
    		{
    			var app = new Microsoft.Office.Interop.Word.Application();
    			app.Visible = true;
    
    			//Load Document
    			Document document = app.Documents.Open(@"C:\Temp\myDocument.docx");
    
    			document.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
    		}
    	}
    }

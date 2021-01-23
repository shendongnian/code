    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System.IO.Packaging;
    using System.Xml;
    using System.IO;
    namespace OpenXMLTest
    {
    class Program
     {
    static void Main(string[] args)
    {
        string fileName = @"c:\temp\book1.xlsx";
        Console.WriteLine("Start reading bookmark of excel...");
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, true))
            {
                WorkbookPart workbookPart = doc.WorkbookPart;
                //find bookmarks
                foreach (var workSheetPart in workbookPart.WorksheetParts)
                {
                    var temp = workSheetPart.RootElement.Descendants<Hyperlinks>();
                    IEnumerable<Hyperlink> hyperLinks = null;
                    if (temp.Count() > 0)
                    {
                        hyperLinks = temp.First().Cast<Hyperlink>();
                    }
                    var workSheet = workSheetPart.Worksheet;
                    var cells = workSheet.Descendants<Cell>();
                    //loop each cell, find bookmark
                    foreach (var c in cells)
                    {
                        if (hyperLinks != null && hyperLinks.Count() > 0)
                        {
                            var hyperLink = hyperLinks.SingleOrDefault(x => x.Reference.Value == c.CellReference.Value);
                            if (hyperLink != null)
                            {
                                if (!string.IsNullOrEmpty(hyperLink.Location))
                                {
                                    Console.WriteLine("Bookmark.DisplayName : " + hyperLink.Display);
                                    Console.WriteLine("Bookmark.Location : " + hyperLink.Location);
                                    //update bookmark
                                    hyperLink.Location = "BookMark_Test";
                                    hyperLink.Display = "updated bookmark";
                                    Console.WriteLine("Bookmark.DisplayName after updated : " + hyperLink.Display);
                                    Console.WriteLine("Bookmark.Location after updated : " + hyperLink.Location);
                                }
                                
                                //for normal hyperlinks
                                //var hr = workSheetPart.HyperlinkRelationships.SingleOrDefault(x => x.Id == hyperLink.Id);
                                //if (hr != null)
                                //{
                                //    Console.WriteLine(hr.Uri.ToString());
                                //}
                            }
                        }
                        workSheet.Save();
                    }
                    workbookPart.Workbook.Save();
                }
               
            }
        }
        Console.ReadKey();
    }
    }
    }

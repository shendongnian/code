    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using System.Xml.Linq;
    
    namespace UnitTest
    {
        [TestFixture]
        public class TestCode
        {
            [Test]
            public void ReadExcelCellTest()
            {
                XDocument document = XDocument.Load(@"C:\TheFile.xml");
                XNamespace workbookNameSpace = @"urn:schemas-microsoft-com:office:spreadsheet";
    
                // Get worksheet
                var query = from w in document.Elements(workbookNameSpace + "Workbook").Elements(workbookNameSpace + "Worksheet")
                            where w.Attribute(workbookNameSpace + "Name").Value.Equals("Settings")
                            select w;
                List<XElement> foundWoksheets = query.ToList<XElement>();
                if (foundWoksheets.Count() <= 0) { throw new ApplicationException("Worksheet Settings could not be found"); }
                XElement worksheet = query.ToList<XElement>()[0];
    
                // Get the row for "Seat"
                query = from d in worksheet.Elements(workbookNameSpace + "Table").Elements(workbookNameSpace + "Row").Elements(workbookNameSpace + "Cell").Elements(workbookNameSpace + "Data")
                        where d.Value.Equals("Seat")
                        select d;
                List<XElement> foundData = query.ToList<XElement>();
                if (foundData.Count() <= 0) { throw new ApplicationException("Row 'Seat' could not be found"); }
                XElement row = query.ToList<XElement>()[0].Parent.Parent;
    
                // Get value cell of Etl_SPIImportLocation_ImportPath setting
                XElement cell = row.Elements().ToList<XElement>()[1];
    
                // Get the value "Leon"
                string cellValue = cell.Elements(workbookNameSpace + "Data").ToList<XElement>()[0].Value;
    
                Console.WriteLine(cellValue);
            }
        }
    }

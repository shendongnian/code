    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Xml.Linq;
    
    namespace XElemFromDT
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, string> htAtributNameForTable = new Dictionary<string, string>()
                {
                    { "Software", "software_entry" },
                    { "ApplicationConfigurations", "config" }
                };
    
                DataTable dt1 = new DataTable();
                dt1.TableName = "Software";
                dt1.Columns.Add("name", typeof(string));
                dt1.Columns.Add("path", typeof(string));
                dt1.Rows.Add("Adobe Acrobat X Standard", @"Applications\Acrobat\Acrobat XStandard\AcroStan.msi");
                dt1.Rows.Add("Adobe Photoshop", @"Applications\Photoshop\Photoshop.msi");
    
                DataTable dt2 = new DataTable();
                dt2.TableName = "ApplicationConfigurations";
                dt2.Columns.Add("name", typeof(string));
                dt2.Columns.Add("value", typeof(string));
                dt2.Rows.Add("someName", "someValue");
                dt2.Rows.Add("someOtherName", "someOtherValue");
    
                DataTable[] dt = new DataTable[] { dt1, dt2 };
    
                XDocument xDoc = new XDocument(new XElement("Root"));
    
                for (int i = 0; i < dt.Length; i++) //for every table 
                {
    
                      XName TableName = dt[i].TableName; //table name.
    
                      XElement[] xInnerElt = new XElement[dt[i].Rows.Count]; //for n rows inside one table
                      for (int j = 0; j < dt[i].Rows.Count; j++) //loop each tag inside the table
                      {
                         XName InnerTagName = htAtributNameForTable[dt[i].TableName].ToString(); //tag name form hash table. i.e, software_entry
                         //I am unable to write the next line
                         xInnerElt[j] = new XElement(InnerTagName);
                          
                          foreach (var column in dt[i].Columns)
                          {
                              xInnerElt[j].Add(
                                  new XAttribute(
                                      (column as DataColumn).ColumnName,
                                      dt[i].Rows[j][(column as DataColumn)].ToString()
                                  )
                              );
                          }
                      }
    
                      XElement xElt = new XElement(TableName, xInnerElt); //one table aded to tag.
                      xDoc.Root.Add(xElt);
                }
    
                Console.WriteLine(xDoc.ToString());
                Console.ReadKey();
            }
        }
    }

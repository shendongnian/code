    using Office = Microsoft.Office.Core;
    using Word = Microsoft.Office.Interop.Word;
    using System.Reflection;
                Office.DocumentProperties properties = (Office.DocumentProperties)Globals.ThisDocument.CustomDocumentProperties;
                //Check if the property exists already
                if (properties.Cast<Office.DocumentProperty>().Where(c => c.Name == "nameofproperty").Count() == 0)
                {
                    //Then add the property and value
                    properties.Add("nameofproperty", false, Office.MsoDocProperties.msoPropertyTypeString, "yourvalue");
                }
                else
                {
                    //else just update the value
                    properties["nameofproperty"].Value = "yourvalue";                    
                }

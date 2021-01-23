using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
namespace OpenXMLTest
{
    class Program
    {
        const string textBoxId = "{8BD21D10-EC42-11CE-9E0D-00AA006002F3}";
        const string radioButtonId = "{8BD21D50-EC42-11CE-9E0D-00AA006002F3}";
        const string checkBoxId = "{8BD21D40-EC42-11CE-9E0D-00AA006002F3}";
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Andy\Desktop\test_l1demo.docx";
            using (WordprocessingDocument doc = WordprocessingDocument.Open(fileName, false))
            {
                foreach (Control control in doc.MainDocumentPart.Document.Body.Descendants<Control>())
                {
                    Console.WriteLine();
                    Console.WriteLine("Control {0}:", control.Name);
                    Console.WriteLine("Id: {0}", control.Id);
                    displayControlDetails(doc, control.Id);
                }
            }
            Console.Read();
        }
        private static void displayControlDetails(WordprocessingDocument doc, StringValue controlId)
        {
            string classId, type, value;
            OpenXmlPart part = doc.MainDocumentPart.GetPartById(controlId);
            OpenXmlReader reader = OpenXmlReader.Create(part.GetStream());
            reader.Read();
            OpenXmlElement controlDetails = reader.LoadCurrentElement();
            classId = controlDetails.GetAttribute("classid", controlDetails.NamespaceUri).Value;
            switch (classId)
            {
                case textBoxId:
                    type = "TextBox";
                    break;
                case radioButtonId:
                    type = "Radio Button";
                    break;
                case checkBoxId:
                    type = "CheckBox";
                    break;
                default:
                    type = "Not known";
                    break;
            }
            value = "No value attribute"; //displays this if there is no "value" attribute found
            foreach (OpenXmlElement child in controlDetails.Elements())
            {
                if (child.GetAttribute("name", controlDetails.NamespaceUri).Value == "Value")
                {
                    //we've found the value typed by the user in this control
                    value = child.GetAttribute("value", controlDetails.NamespaceUri).Value;
                }
            }
            reader.Close();
            Console.WriteLine("Class id: {0}", classId);
            Console.WriteLine("Control type: {0}", type);
            Console.WriteLine("Control value: {0}", value);
        }
    }
}

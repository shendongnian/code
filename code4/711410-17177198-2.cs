    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    
    namespace MyNamespace
    {
        public class EmployeesToXmlConverter
        {
            public string ConvertToXmlString(ICollection<EmployeePoco> emps)
            {
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb);
    
                writer.WriteStartElement("root");
    
                if (null != emps && emps.Any())
                {
                    writer.WriteStartElement("Employees");
                    foreach (EmployeePoco emp in emps)
                    {
                        writer.WriteStartElement("Employee");
                        writer.WriteAttributeString("EmployeeKey", Convert.ToString(emp.EmployeeKey));
                        writer.WriteAttributeString("LastName", emp.LastName);
                        writer.WriteAttributeString("FirstName", emp.FirstName);
                        writer.WriteEndElement(); ////closing patient tag
                    }
    
                    writer.WriteEndElement(); ////closing emps tag
    
                }
    
                writer.WriteEndElement(); ////closing root tag
                writer.Close();
                string returnValue = sb.ToString();
                return returnValue;
            }
        }
    }

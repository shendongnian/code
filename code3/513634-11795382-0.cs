    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace anonymousTypes
    {
        class Program
        {
            static void Main(string[] args)
            {
                el("td", null, new { colspan = 36 }, new { style = "text-align: center;" });
                Console.Read();
            }
            static string el(string tagName, string innerHTML, params object[] objects)
            {
                StringBuilder b = new StringBuilder();
                b.Append("<").Append(tagName);
                foreach (object obj in objects)
                {
                    foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
                    {
                        Console.Write(propertyInfo.Name + " | " + propertyInfo.GetValue(obj, null) + "\n");
                    }
                }
                b.Append(">");
                if (innerHTML != null)
                    b.Append(innerHTML);
                b.Append("</").Append(tagName).Append(">");
                return b.ToString();
            }
        }
    }

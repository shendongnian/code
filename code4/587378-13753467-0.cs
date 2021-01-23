    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    using ConsoleApplication2.Properties;
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //throw an DivideByZeroException
                var a=0;
                var b=1/a;
            }
            catch (Exception ex)
            {
                //using the ExceptionXElement class
                var xmlException = new ExceptionXElement(ex);
                XslCompiledTransform myXslTrans = new XslCompiledTransform();
                //Resources.formatter is the xsl file added as a Resource to the project (ConsoleApplication2.Properties.Resources.formatter)
                //So, here we load the xsl
                myXslTrans.Load(XmlReader.Create(new StringReader(Resources.formatter)));
                //initialize a TextWriter, in this case a StringWriter and set it to write to a StringBuilder
                StringBuilder stringBuilder = new StringBuilder();
                XmlTextWriter myWriter = new XmlTextWriter(new StringWriter(stringBuilder));
                //apply the XSL transformations to the xmlException and output them to the XmlWriter
                myXslTrans.Transform(xmlException.CreateReader(), null, myWriter);
                //outputting to the console the HTML exception (you can send it as the message body of an email)
                Console.WriteLine(stringBuilder);
            }
        }
    }

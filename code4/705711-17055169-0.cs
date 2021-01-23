    class RegexForBadXml
    {
        const string Input = "<?xml version=\"1.0\"?>\r\n<div>\r\n\t<a href=\"link\">Link with < characters</a>\r\n\t<knownTag>Text with character > &and other &#BAD; stuff</knownTag>\r\n\t<knownTag>Text < again ></knownTag>\r\n\t<knownTag><![CDATA[ Text < again > ]]></knownTag>\r\n<div>";
        private static void Main()
        {
            var output = new StringWriter();
            XmlLightParser.Parse(Input, XmlLightParser.AttributeFormat.Html, new OutputFormatter(output));
            Console.WriteLine(output.ToString());
        }
        private class OutputFormatter : IXmlLightReader
        {
            private readonly TextWriter _output;
            public OutputFormatter(TextWriter output)
            {
                _output = output;
            }
            void IXmlLightReader.StartDocument() { }
            void IXmlLightReader.EndDocument() { }
            public void StartTag(XmlTagInfo tag)
            {
                _output.Write(tag.UnparsedTag);
            }
            public void EndTag(XmlTagInfo tag)
            {
                _output.Write(tag.UnparsedTag);
            }
            public void AddText(string content)
            {
                _output.Write(HttpUtility.HtmlEncode(HttpUtility.HtmlDecode(content)));
            }
            public void AddComment(string comment)
            {
                _output.Write(comment);
            }
            public void AddCData(string cdata)
            {
                _output.Write(cdata);
            }
            public void AddControl(string cdata)
            {
                _output.Write(cdata);
            }
            public void AddInstruction(string instruction)
            {
                _output.Write(instruction);
            }
        }
    }

        private string MakeReadOnly(string xml) 
        {
            string formName = GetFormName(xml);
            return @"
    ProcessAllFields(xfa.form." + formName + @");
    function ProcessAllFields(oNode) {
        if (oNode.className == 'exclGroup' || oNode.className == 'subform'  || oNode.className == 'subformSet' || oNode.className == 'area') { 
	    for (var i = 0; i < oNode.nodes.length; i++) {
                var oChildNode = oNode.nodes.item(i); ProcessAllFields(oChildNode);
            }
        } else if (oNode.className == 'field') {
            oNode.access = 'readOnly'
        }
    }";
        }
        private string GetFormName(string xml)
        {
            string formName = string.Empty;
            int subFormStart = xml.IndexOf("<subform", 0);
            if (subFormStart > -1)
            {
                int nameTagStart = xml.IndexOf("name", subFormStart);
                int nameStart = xml.IndexOf("\"", nameTagStart);
                int nameEnd = xml.IndexOf("\"", nameStart + 1);
                formName = xml.Substring(nameStart + 1, (nameEnd - nameStart) - 1);
            }
            return formName;
        }

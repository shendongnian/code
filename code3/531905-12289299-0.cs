    String myxml = "<instructions>"+
                    "<step index=\"1\">Do this</step>"+
                    "<step index=\"2\">Do that</step>"+
                    "</instructions>";
    
     public void populateNewXML()
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(textBoxInstructions.Text);
                var attr = xmlDoc.CreateAttribute("iterations");
                attr.InnerText = "3";
                xmlDoc.GetElementsByTagName("instructions")[0].Attributes.Append(attr);
                textBoxInstructions.Text = xmlDoc.InnerXml;
            }

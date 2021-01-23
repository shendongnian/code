            object ICloneable.Clone()
            {
                string stCopie = System.Windows.Markup.XamlWriter.Save(this);
    
                var Copie = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(new System.IO.StringReader(stCopie))) as Structure;
                return Copie;
            }

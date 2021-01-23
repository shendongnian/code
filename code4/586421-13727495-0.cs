    XElement root = new XElement("Form");
    TraverseAllControls(root, this);
    var xml = root.ToString();
---
    void TraverseAllControls(XElement xElem,Control ctrl)
    {
        foreach (Control c in ctrl.Controls)
        {
            if (String.IsNullOrEmpty(c.Name)) continue;
            var e = new XElement(c.Name, 
                        new XElement("Width",c.Width), 
                        new XElement("Height",c.Height),
                        new XElement("X",c.Location.X),
                        new XElement("Y",c.Location.Y));
            xElem.Add(e);
            TraverseAllControls(e, c);
        }
    }

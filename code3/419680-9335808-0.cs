        var xd = new XmlDocument();
        xd.LoadXml("<root><nodes><node>1</node><node>2</node></nodes></root>");
        var xnl = xd.SelectSingleNode("/root/nodes").Clone();
        foreach (XmlNode n in xnl)
        {
            n.InnerText = "x";
        }
        Console.Out.WriteLine(xd.OuterXml);
        Console.Out.WriteLine("--------------");
        Console.Out.WriteLine(xnl.OuterXml);

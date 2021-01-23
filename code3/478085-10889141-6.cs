    string xml =
    "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
    "<Root Attr1=\"Foo\" Name=\"MyName\" Attr2=\"Bar\" >" +
    "    <Parent1 Name=\"IS\">" +
    "        <Child1 Name=\"Kronos1\">" +
    "            <GrandChild1 Name=\"Word_1\"/>" +
    "            <GrandChild2 Name=\"Word_2\"/>" +
    "            <GrandChild3 Name=\"Word_3\"/>" +
    "            <GrandChild4 Name=\"Word_4\"/>" +
    "        </Child1>" +
    "        <Child2 Name=\"Kronos2\">" +
    "            <GrandChild1 Name=\"Word_1\"/>" +
    "            <GrandChild2 Name=\"Word_2\"/>" +
    "            <GrandChild3 Name=\"Word_3\"/>" +
    "            <GrandChild4 Name=\"Word_4\"/>" +
    "        </Child2>" +
    "    </Parent1>" +
    "</Root>";
    
    string search = "MyName.IS.Kronos1.Word_1";
    string[] names = search.Split('.');
    
    IEnumerable<XElement> currentSelection = XElement.Parse(xml).AncestorsAndSelf();
    IEnumerable<XElement> elements = currentSelection;
    currentSelection.Dump();
    
    foreach (string name in names)
    {
        currentSelection =
            from el in elements
            where el.Attribute("Name").Value == name
            select el;
        elements = currentSelection.Elements();
        currentSelection.Dump();
    }

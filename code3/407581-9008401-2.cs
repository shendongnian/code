    XDocument document = XDocument.Parse(@"
        <states>
            <state Name=""Florida"">
            <Person Name=""a1"">
                <Address>a2</Address>
            </Person>
            <Person Name=""b1"">
                <Address>b2</Address>
            </Person>
            <Person Name=""c1"">
                <Address>c2</Address>
            </Person>
            </state>
            <state Name=""New York"">
            <Person Name=""aa1"">
                <Address>aa2</Address>
            </Person>
            <Person Name=""bb1"">
                <Address>bb2</Address>
            </Person>
            </state>
        </states>");
            
    IDictionary<string, Dictionary<string, string>> dictionary =                
        document.Root.Elements("state").ToDictionary(
            state => state.Attribute("Name").Value,
            state => state.Elements("Person").ToDictionary(
                person => person.Attribute("Name").Value,
                person => person.Element("Address").Value));
    // To get address of "a1" living in Florida:
    string addr1 = dictionary["Florida"]["a1"];      // gives "a2"
    // To get address of "bb1" living in New York:
    string addr2 = dictionary["New York"]["bb1"];    // gives "bb2"

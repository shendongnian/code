       const string myXml = @"<Critic-List>
                                       <Movie Title='White House Down (2013)' Score='C+' />
                                       <Movie Title='Despicable Me 2 (2013)' Score='A-' />
                                       <Movie Title='World War Z (2013)' Score='B+' />
                                       <Movie Title='Man of Steel (2013)' Score='B+' />
                             </Critic-List>";
    
       var el = XElement.Parse(myXml);
       var q1 = el.Elements().Select(node => (node.Attribute("Title").Value == "Despicable Me 2 (2013)") ? node.Attribute("Score") : null).First(n => n != null);

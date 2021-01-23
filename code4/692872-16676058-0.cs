    string xml =
    @"<Child>
      <Child1 Id='1'>
        <Child2 Id='2'>
          <Child3 Id='3'>
            <Child4 Id='4'>
              <Child5 Id='5'/>
                <Child6 Id='6'/>
            </Child4>
         </Child3>
       </Child2>
      </Child1>
    </Child>";
    
    
    var doc = XDocument.Parse( xml );
    
    // assumes there will always be an Id attribute for each node
    // and there will be an Id with a value of 4
    // otherwise an exception will be thrown.
    XElement el = doc.Root.Descendants().First( x => x.Attribute( "Id" ).Value == "4" );
    // discared all child nodes
    el.RemoveNodes();
    
    // walk up the tree to find the parent; when the
    // parent is null, then the current node is the 
    // top most parent.
    while( true )
    {
        if( el.Parent == null )
        {
            break;
        }
    
        el = el.Parent;
    }

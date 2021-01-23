    List<A<A_Content>> list = new List<A<A_Content>>();
    
    list.Add(new B()); // this seems OK so far, right? 
    
    A<A_Content> foo = list[0];
    
    foo.content = new A_Content():

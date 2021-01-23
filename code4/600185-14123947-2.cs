    public void ProcessNextPage() {
    
       if(stack.Count == 0) //INFINIT LOOP BREAK CONDITION
            return;
    
       var pageToProcess = stack.Pop();
       Task.StartNew(t=> {
           /*DO SOMETHING WITH pageToProcess*/
       }).ContinueWith(a=>processNextPage()); //ON COMPLETE, CALL MYSELF (RECURSION)
    }

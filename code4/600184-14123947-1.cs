    public void ProcessNextrPage() {
    
       if(stack.Count == 0) //INFINIT LOOP BREAK CONDITION
            return;
    
       var pageToProcess = stack.Pop();
       Task.StartNew(t=> {
           /*DO SOMETHING WITH pageToProcess*/
       }).ContinueWith(processNextPage();); //ON COMPLETE, CALL MYSELF (RECURSION)
    }

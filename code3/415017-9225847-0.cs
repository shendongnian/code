    public void doSomeThing(Stack stack)
    {
        Contract.Requires(stack != null);
    
        stack.Push("$");
        Contract.Assert(stack.Count > 0); //redundant check
        _Look(stack);
        Contract.Assert(stack.Count > 0); //this contract fails static analysis, because analyser does not know that _Look does not write to stack.
        stack.Pop();
    }
    
    private void _Look(Stack stack)
    {
        Contract.Ensures(stack.Count == Contract.OldValue(stack.Count));
    }

    public void MyFunctionWhereIAddNew()
    {
        var item  = _myBindingSource.AddNew();
        
        item.SetSomeParams(...);
        if(item.CheckItemForSuccess() != true)
        {
            _myBindingSource.CancelNew(_myBindingSource.IndexOf(item));
        }
    }

    public ActionMethod MyPage(int parentId)
    {
        var myView = new MyViewModel();
        myView.Items = _service.GetItems(parentId);
    }

    [HttpPost]
    public ActionResult ItemUpdate(object arg)
    {
        if (arg.GetType() == typeof(ORDER))
        {
            return ItemUpdateOrder((Order)arg);
        }
        else if (arg.GetType() == typeof(List<ORDER>))
        {
            return ItemUpdateList((List<Order>)arg);
        }
    }
    public ActionResult ItemUpdateOrder(ORDER ln)
    {
        //...
    }
    public ActionResult ItemUpdateList(List<ORDER> lns)
    {
        //...
    }

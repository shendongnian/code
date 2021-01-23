    public Order MergeChanges(Order newOrder)
    {
        var sessionHistory = (List<string>)Session["sessionHistory"];
        if (sessionHistory == null || sessionHistory.Count == 0)
        return MergeChanges(newOrder, -1);
        return MergeChanges(newOrder, MasterViewController.GetStepNumberByName(sessionHistory.Last()));
    }
    public Order MergeChanges(Order newOrder, int step)
    {
        PreMerge(newOrder);
        Order result = null;
        try
        {
        ApplyLookups(ref newOrder);
        Order oldOrder = (Order)Session["order"];
        if (oldOrder == null)
        {
            Session["order"] = newOrder;
            result = newOrder;
        }
        else
        {
            List<TypeHelper.DecoratedProperty<ModelPageAttribute>> props = null;
            newOrder.GetType().GetDecoratedProperty<ModelPageAttribute>(ref props);
            props = props.Where(p => (p.Attributes.Count() > 0 && p.Attributes.First().PageNumber.Contains(step))).ToList();
            foreach (var propPair in props)
            {
            object oldObj = oldOrder;
            object newObj = newOrder;
            if (!string.IsNullOrEmpty(propPair.PropertyPath))
            {
                bool badProp = false;
                foreach (string propStr in propPair.PropertyPath.Split('\\'))
                {
                var prop = oldObj.GetType().GetProperty(propStr);
                if (prop == null)
                {
                    badProp = true;
                    break;
                }
                oldObj = prop.GetValue(oldObj, BindingFlags.GetProperty, null, null, null);
                newObj = prop.GetValue(newObj, BindingFlags.GetProperty, null, null, null);
                }
                if (badProp)
                continue;
            }
            if (newObj == null)
                continue;
            var srcVal = propPair.Property.GetValue(newObj, BindingFlags.GetProperty, null, null, null);
            var dstVal = propPair.Property.GetValue(oldObj, BindingFlags.GetProperty, null, null, null);
            var mergeHelperAttr = propPair.Property.GetAttribute<MergeHelperAttribute>();
            if (mergeHelperAttr == null)
            {
                if (newObj != null)
                propPair.Property.SetValue(oldObj, srcVal, BindingFlags.SetProperty, null, null, null);
            }
            else
            {
                var mergeHelper = (IMergeHelper)Activator.CreateInstance(mergeHelperAttr.HelperType);
                if (mergeHelper == null)
                continue;
                mergeHelper.Merge(context, HttpContext.Request, newObj, propPair.Property, srcVal, oldObj, propPair.Property, dstVal);
            }
            }
            result = oldOrder;
        }
        }
        finally
        {
        PostMerge(result);
        }
        return result;
    }

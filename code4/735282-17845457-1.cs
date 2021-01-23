    var enumerator = mgr.GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true).GetEnumerator();
    while (enumerator.MoveNext())
    {
      var current = enumerator.Entry;
      var objName = current.Key.ToString().Split('.')[0];
      var item = this.GetType().GetField( objName, BindingFlags.NonPublic | BindingFlags.Instance );
      if (item != null)
      {
          mgr.ApplyResources(item.GetValue(this), objName);
      }
    }

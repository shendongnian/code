      var selectList = new SelectList(new Dictionary<int, int> { { 1, 2 }, { 3, 4} });
      var privateFields = selectList.GetType().BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
      privateFields.Single(i => i.Name.Contains("DataTextField"))
                   .SetValue(selectList, "value");
      privateFields.Single(i => i.Name.Contains("DataValueField"))
                   .SetValue(selectList, "key");

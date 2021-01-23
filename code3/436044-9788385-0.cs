    [Test]
    public void DataIn_NoOfRowsReached_CreatesSequentialData([Values(new string[] { "1,4,7", "2,5,8", "3,6,9" }, ...)] string[] vals)
    {
        //Assert
        MyLogic logic = SetupLogic();
        logic.NoOfRows = vals.Length;
        for (var i = 0; i < vals.Length; ++i)
          logic.DataIn(i + 1, vals[i]);
        CollectionAssert.AreEqual(new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }, logic.ExpectedValues);
    }

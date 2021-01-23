    [Test]
    public void DataIn_NoOfRowsReached_CreatesSequentialData()
    {
        MyGenericTest("1,4,7", "2,5,8", "3,6,9");
    }
    private void MyGenericTest(params string[] inputs)
    {
        //Assert
        MyLogic logic = SetupLogic();
        logic.NoOfRows = inputs.Length;
        List<string> allNumbers = new List<string>();
        for(int i = 0; i < inputs.Length; i++)
        {
           logic.DataIn(i + 1, inputs[i]);
           allNumbers.AddRange(inputs[i].Split(',');
        }
         
        allNumbers.Sort();
        CollectionAssert.AreEqual(allNumbers.Distinct(), logic.ExpectedValues);
    }

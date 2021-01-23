    MyGenericTest("1,4,7", "2,3,6");
    public void MyGenericTest(params string[] inputs)
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
         
        CollectionAssert.AreEqual(allNumbers.Sort().Distinct(), logic.ExpectedValues);
    }

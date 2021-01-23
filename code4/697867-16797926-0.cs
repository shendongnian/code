    private List<TestClass> GetByModuleAndTopBot(List<TestClass> list, int modulePosition, int topBotData)
    {
        List<TestClass> result = new List<TestClass>();
        foreach (TestClass test in list)
        {
            if ((test.ModulePosition == modulePosition) &&
                (test.TopBotData == topBotData))
                result.Add(test);
        }
        return result;
    }

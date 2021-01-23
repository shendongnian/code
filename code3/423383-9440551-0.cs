    public struct MyData
    {
        public List<string> myMapList;
        public List<string> gameMode;
        public List<int> numRounds;
        public List<string> variableNames;
        public List<List<string>> customVariables;
        public List<string> defaultVariables;
        public List<string> defaultVariablesBackup;
    }
    private void SaveAllData()
    {
        string dataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.txt");
    
        MyData myData = new MyData()
        {
            myMapList = myMapList,
            gameMode = gameMode,
            numRounds = numRounds,
            variableNames = variableNames,
            customVariables = customVariables,
            defaultVariables = defaultVariables,
            defaultVariablesBackup = defaultVariablesBackup
        };
        XmlSerializer serializer = new XmlSerializer(typeof(MyData));
        TextWriter writer = new StreamWriter(dataFile);
        serializer.Serialize(writer, myData);
        writer.Dispose();
        writer = null;
    }
    private void LoadAllData()
    {
        string dataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.txt");
    
        XmlSerializer serializer = new XmlSerializer(typeof(MyData));
        TextReader reader = new StreamReader(dataFile);
        MyData myData = (MyData)serializer.Deserialize(reader);
        reader.Dispose();
        reader = null;
    
        myMapList = myData.myMapList;
        gameMode = myData.gameMode;
        numRounds = myData.numRounds;
        variableNames = myData.variableNames;
        customVariables = myData.customVariables;
        defaultVariables = myData.defaultVariables;
        defaultVariablesBackup = myData.defaultVariablesBackup;
    }

    for (int i = 0; i < ControllerDictionary.Count; i++)
    {
        var value = ControllerDictionary[i];
        Thread MoveThread = new Thread(() => MoveTask(value));
        ... 
    }

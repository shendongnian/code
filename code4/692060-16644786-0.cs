    for (int i = 0; i < ControllerDictionary.Count; i++)
    {
        int index = i;
        Thread MoveThread = new Thread(() => MoveTask(ControllerDictionary[index]));
        ... 
    }

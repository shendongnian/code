        //Create your decision table Dictionary
        Dictionary<int, Action> decisionTable = new Dictionary<int, Action>();
        Action actionToPerform1 = () => Console.WriteLine("The number is okay");
        Action actionToPerform2 = () => Console.WriteLine("The number is not okay");
        //Your conditions
        decisionTable.Add(1, actionToPerform1);
        decisionTable.Add(2, actionToPerform1);
        decisionTable.Add(3, actionToPerform1);
        decisionTable.Add(4, actionToPerform2);
        decisionTable.Add(5, actionToPerform2);
        decisionTable.Add(6, actionToPerform2);
        //According to the given number, the right *Action* will be called!
        int theNumber = 3;
        decisionTable[3](); //actionToPerform1 will be called in that case!

    foreach (ActionPerformer.PossibleActions action in Enum.GetValues(typeof(ActionPerformer.PossibleActions)))
    {
        //If a file exists with the same name as the current action
        if (File.Exists(_location + action.ToString()))
        {
            var actionCopy = action;
            //Delete "message" and create a new thread to perform this action.
            File.Delete(_location + action);
            Thread _t = new Thread(() => 
            { 
                new ActionPerformer(actionCopy);
            });
            _t.SetApartmentState(ApartmentState.STA);
            _t.Start();
            //Add thread to list so they can be joined propperly
            _list.Add(_t);
            //Write information to log
            Logger.LogInfo(_t, "Starting new action: " + action.ToString(), DateTime.Now);
        }
    }

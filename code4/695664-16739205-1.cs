    RemoveValidationError("FunkyThingsOrder.CustomerName");
    RemoveValidationError("FunkyThingsOrder.ContactNumber");
    RemoveValidationError("FunkyThingsOrder.EmailAddress");
    protected void RemoveValidationError(string name)
    {
        for (var i = 0; i < ModelState.Keys.Count; i++)
        {
            if (ModelState.Keys.ElementAt(i) == name &&
                ModelState.Values.ElementAt(i).Errors.Count > 0)
            {
                ModelState.Values.ElementAt(i).Errors.Clear();
                break;
            }
        }
    }

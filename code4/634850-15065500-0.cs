    bool checkResult = IsNullOrEmptyControl(txtClientCode, txtClientName);
    if(checkResult == false)
    {
        return false;
    }
    some code..
    clientService.Save(entity);

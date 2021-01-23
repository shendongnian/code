    public bool Save()
    {
        //some code...
        if(IsNullOrEmptyControl(txtClientCode, txtClientName))
        {
            //some code..
            clientService.Save(entity);
        }
    }

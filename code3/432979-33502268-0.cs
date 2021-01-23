    string status = "";
    string description = "";
    int handle = fax.Handle; // this identifies the fax object you're polling for
    while (status != "fsDoneOK") // keep polling fax object until status is "OK"
    {    
        foreach (Fax obj_fax in obj_user.Folders["Main"].Faxes) // look in the "Main" folder for fax objects
        {
            if (handle == obj_fax.Handle) // check to see if this object is yours
            {
                status = obj_fax.FaxStatus.ToString();
                description = obj_fax.StatusDescription;
                System.Diagnostics.Debug.WriteLine("Fax Status: " + obj_fax.StatusDescription);
            }
            if (status == "fsDoneError" || status == "fsError") // check for fax error
                break;
        }
        if (status == "fsDoneError" || status == "fsError") // check for fax error
            break;  
        Thread.Sleep(3000); // sleep for 3 seconds and then poll again
    }

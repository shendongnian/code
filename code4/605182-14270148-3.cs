    1. Let the users write to the same file
    2. capture the users Machine Name or User Id then
    2. write a line in your file like this 
    
    strSeprate = new string('*',25); 
    //will write to the file "*************************";
    f.Write(strSeprate);
    f.Write(Machine Name or UserId);
    f.Write(data);
    f.Write(DateTime.Now.ToString());
    f.Write(strSeprate);

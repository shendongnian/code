    Collection<PSObject> colpsObject = new Collection<PSObject>();
    PSObject obj1 = new PSObject();
    obj1.Properties.Add(new PSNoteProperty("Name1", "Value1"));
    obj1.Properties.Add(new PSNoteProperty("Name2", "Value2"));
    colpsObject.Add(obj1);
    PSObject obj2 = new PSObject();
    obj2.Properties.Add(new PSNoteProperty("Name1", "Value1"));
    obj2.Properties.Add(new PSNoteProperty("Name2", "Value2"));
    colpsObject.Add(obj2);
    PowershellRunspace rs = new PowershellRunspace(); //Custom Powershell class
    rs.Open();
    Command cmd1 = new Command("param($Param1);$Param1",true);
    cmd1.Parameters.Add("Param1", colpsObject);
    rs.Add(cmd1);
    Command cmd2 = new Command(m_Script);
    cmd2.Parameters.Add("Username", m_userName);
    cmd2.Parameters.Add("Password", m_password);
    rs.Add(cmd2);
    rs.Execute();

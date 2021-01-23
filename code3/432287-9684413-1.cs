    private char _letter;
    private string _fullName;
    public char Letter{
    get{
    return _letter;
    }
    set{
    _letter = value;
    }
    }
    public string FullName{
    get{
    return _fullName;
    }
    set{
    _fullName = value;
    }
    }
    Private Void UpdateToolTipButton(){
    string fullname;
    codons cdn;
    char letter;
    OleDbConnection iConnect = new OleDbConnection();
    iConnect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data 
    Source=C:\Projects_2012\Project_Noam\Access\myProject.accdb";
    OleDbCommand iCommand = new OldDbCommand("Select * from  tblCodons",iConnect);
    List<YourClassName> iList = new List<YourClassName>();
    OleDbDataReader iRead = null;
    iRead = iCommand.ExecuteReader();
    while(iRead.Read()){
    YourClassName iClass = new YourClassName();
    iClass.Letter = Convert.ToChar(iRead["codonsCodon1"]);
    iClass.FullName = Convert.ToString(iRead["codonsFullName"]);
    iList.Add(iClass);
    }
    iConnect.Close();
    iRead.Close();
    foreach(var VarName in iList)
    {
    toolTip1.SetToolTip(var.Letter,"Name: " + var.FullName + " ("+cdn.GetCodon1()+")"
                              +"\n Begin: "+cdn.GetStart()+", End: "+cdn.GetEnd()+"");
    }
    }

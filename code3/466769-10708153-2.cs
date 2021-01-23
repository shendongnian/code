protected Change SetupApproval(string changeDescription) 
{
    ParameterSource p = new FakeParameterSource { Value = "mypath" }; 
    Change change = Change.GetInstance(); 
    change.Description = changeDescription; 
    change.DateOfChange = DateTime.Now; 
    change.Page = GetPageName(p); //  now uses the value in the parameter source
    return change; 
} 

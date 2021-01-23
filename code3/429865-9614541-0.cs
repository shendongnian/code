private bool ValidMail(string adresse)
{ 
    System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
    return myRegex.IsMatch(adresse);
}

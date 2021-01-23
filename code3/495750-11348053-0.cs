    public string MakePropertyBigger(string varName, string propName, string dataType)
    {
        string output = "";
        output += string.Format("private {0} {1};", dataType, varName) + Environment.NewLine;
        output += string.Format("public {0} {1}", dataType, propName) + Environment.NewLine;
        output += "{" + Environment.NewLine;
        output += string.Format("get { return {0}; }", varName) + Environment.NewLine;
        output += string.Format("set { if({0} != value){ SetChanged(\"{1}\");", varName, propName) + Environment.NewLine;
        output += string.Format("{0} = value; }", varName) + Environment.NewLine;
        output + "}" + Environment.NewLine + "}";

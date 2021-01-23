     bool fQuotedIdenfifiers = false;
     var _parser = new TSql100Parser(fQuotedIdenfifiers);
  
     SqlScriptGeneratorOptions options = new SqlScriptGeneratorOptions();
     options.SqlVersion = SqlVersion.Sql100;
     options.KeywordCasing = KeywordCasing.UpperCase;
  
     _scriptGen = new Sql100ScriptGenerator(options);
        IScriptFragment fragment;
       IList<ParseError> errors;
       using (StringReader sr = new StringReader(inputScript))
       {
           fragment = _parser.Parse(sr, out errors);
       }
    
       if (errors != null && errors.Count > 0)
       {
           StringBuilder sb = new StringBuilder();
           foreach (var error in errors)
           {
               sb.AppendLine(error.Message);
               sb.AppendLine("offset " + error.Offset.ToString());
           }
           var result = sb.ToString();
       }
       else
       {
           String script;
           _scriptGen.GenerateScript(fragment, out script);
           var result = script;
       }

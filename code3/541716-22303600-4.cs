    string conditiontext = "(([age] >= 28) && ([nationality] == \"US\"))";
    conditiontext = conditiontext.Replace("[age]", 32)
                                 .Replace("[nationality]","US");
    
    /*VsaEngine*/
    var engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
    
    /** Result will be either true or false based on evaluation string*/
    var result = Microsoft.JScript.Eval.JScriptEvaluate(conditiontext, engine);

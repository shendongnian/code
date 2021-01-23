    protected DTE2 dte;
    dte2 = (EnvDTE80.DTE2)GetService(typeof(EnvDTE.DTE));
    
    public string GetCurrentTextFile(){
    
      TextDocument doc = (TextDocument)(dte.ActiveDocument.Object("TextDocument"));
      var p = doc.StartPoint.CreateEditPoint();
      string s = p.GetText(doc.EndPoint);
      
      return s;            
    }

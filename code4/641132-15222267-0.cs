    class ScriptData
    {
      public ScriptData(string script)
      {
        this.ScriptHash=script.GetHashCode();
        this.Script=script;
      }
    
      public int ScriptHash{get;private set;}
      public string Script{get;private set;}
    }

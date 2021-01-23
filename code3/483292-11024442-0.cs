    public IEnumerable<string> GetStrings(){
    
        if (stringList == null)
           LoadResource();
    
        foreach (string line in stringList){
            yield return line;
        }
    }

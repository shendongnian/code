    public override int GetHashCode(){
        foreach(Symbol c in Symbols){
    
           int hashCode |= c.ToOpCode();
    
        }
    }

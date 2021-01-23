    public void AbsFoo(){
       lock(obj){
          doActualWork();
       }
    }
    
    protected abstract void DoActualWork();

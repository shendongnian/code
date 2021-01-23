    void errorHandling(Exception e)
    {
      // Your BUNCH of logic
    }
    public void Function1(){
       try {
         do something
       }catch(Exception e) {
          errorHandling(e);
       }
    }
    
    public void Function2() {
       try {
         do something different
       }catch(Exception e) {
          errorHandling(e);
       }
    }

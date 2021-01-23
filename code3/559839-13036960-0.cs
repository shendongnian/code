    bool iseditableSet=false;
    override bool IsEditable
    {
        get;
        set
        {
          if(!iseditableSet){
            iseditableSet=true;
            base.IsEditable=value;
          }else{
            throw Exception...
        }     
    }

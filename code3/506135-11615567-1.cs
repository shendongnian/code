    public Action  del;
    void Main()
    {
    
    del+=(()=>"1".Dump());
    
     del+=null;
     del+=null;
     del+=null; 
     
    del+=(()=>"2".Dump());
    del();
    del.GetInvocationList().Select(f=>f.Target);
    	 
    }
    //ouput:
    1
    2

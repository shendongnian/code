    public HttpResponseMessage Post(object obj)
    {
        MyDTO dto = obj as MyDTO;
        if (dto != null)
        { 
          ...
        }
        ...
    }  

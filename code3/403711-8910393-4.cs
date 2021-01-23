        public Client Insert()
        {
        try
           {
            _repository.Insert(client);
           } 
        catch(DalException ex)
           {
    //wrap message since, error will always be in client entity as client's method is being called. Also, insertion is being failed.
             throw new BusinessException(string.Format(ex.message), "Insertion", "Client");
           }
        }

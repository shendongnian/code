    public Client Insert()
    {
    try
       {
        _repository.Insert(client);
       } 
    catch(DalException ex)
       {
         throw new BusinessException(string.Format(ex.message), "Insertion", "Client");
       }
    }

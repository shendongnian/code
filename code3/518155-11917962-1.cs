    private Dictionary<int,object> _operableIds = new Dictionary<int,object>();
    ...
    private void Start()
    {
        _operableIds.Clear();
        Recurtion(start_id);
    }
    ...
    private void Recurtion(int object_id)
    {
       if(_operableIds.ContainsKey(object_id))
          throw new Exception("Have a ring!");
       else
         _operableIds.Add(object_id, null/*or object*/);
       ...
       Recurtion(other_id)
       ...
       _operableIds.Remove(object_id);
    }

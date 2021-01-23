    List<student> oldList = new List<student> { new student{
                                                 id=122,
                                                 name="John"} };
    IEnumerable<student> copy= oldList.Select(item => new student{
                                                 id = item.id,
                                                 name = item.name });
    List<student> newList= new List<student>(copy);

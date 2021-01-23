    public interface IPerson
    {
       Name { get; set; }
       LastName { get; set; }
       Age { get; set; }
    }
    
    private void dosomething(List<IPerson> persons) {
        ... 
    }

    public class ParentMapper
    {
        public Parent MapFromSource(ParentDo parentDo)
        {
            Parent parent = new Parent();
            parent.Id = parentDo.Id;
            return parent;
        }
    }  

    public class Repository
    {
        //you already have parentDo
        //you already have childDo
        public Parent GetParent()
        {
            Parent parent = parentMapper.MapFromSource(parentDo);
            parent.Child = childMapper.MapFromSource(childDo);
            return parent;
        }
        public Child GetChild()
        {
            Child child = childMapper.MapFromSource(childDo);
            return child;
        }
    }  

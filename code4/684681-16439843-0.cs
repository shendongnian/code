    public class SubGroup{
        public SubGroup(Group group){
            if(group == null) {
                throw new InvalidOperationException("A subgroup must has a group");
            }
            this.group = group;
        }
        Group group;
    }

    class Group{  
       List<SubGroup> list;
       ... 
       public void AddSubgroup(SubGroup sub) {
           list.Add(sub);
       }
     }
    
    class SubGroup{
     
      ///private ctor, can be used only inside class
      private SubGroup(int arg){
      }
    
      public static Subgroup Create(Group parent, int arg) {
           Subgroup sub = new Subgroup(arg);//use private ctor
           parent.AddSubgroup(sub);
           return sub;
      }
    
     }

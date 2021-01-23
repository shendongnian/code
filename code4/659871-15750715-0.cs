    public class CustomerMap : ClassMap<Customer>{
      public CustomerMap(){
            //...other columns mappings
            
            References(c=>c.Comment).Column("CommentId");
      }
    }

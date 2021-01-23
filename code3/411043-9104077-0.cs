     public class ClassOne 
     {
         public ClassOne()
         {
         }
     
         public virtual int ID {get;set;}
         // More properties here
     
         public virtual void Set(){
             // Do Stuff to save this
         }
         // More Methods here }
     
     public class ClassTwo : ClassOne 
     { 
        public string ClassTwoString { get; set; }
     }
     
     public class ClassThree : ClassOne 
     { 
        public string ClassThreeString { get; set; }
     }

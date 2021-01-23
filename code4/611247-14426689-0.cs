    using System.ComponentModel; 
    
    public class ClassName
     {    
       public ClassName ()
            {
                RememberMe = false;
            }
        
       [DefaultValue(false)]
       [Display(Name = "Remember me?")]
       public bool RememberMe { get; set; }
     }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WpfApplication1
    {
        public class Customer
        {
            public String JointName { get; set; }
            public String ActionName { get; set; }
           
    
            public Customer(String joint, String action)
            {
                this.JointName = joint;
                this.ActionName = action;
              
            }
    
           
        }
    }

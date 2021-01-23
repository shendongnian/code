    namespace ActiveCitizenSystemMimic.Models
    {
        using System;
        using System.Collections.Generic;
    
        public partial class ActiveCitizenProperties
        {
            public int FK_ActiveCitizen { get; set; }
            public int FK_PropertyType { get; set; }
    
            public ActiveCitizenProperties(int a, int b)
            {
                this.FK_ActiveCitizen = a;
                this.FK_PropertyType = b;
            }
        }
    }

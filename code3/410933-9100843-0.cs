    class Parent
        {
            public virtual bool MyField { get; set; }
        }
    
        class Child : Parent
        {
            public override bool MyField
            {
                //ommitting get portion
                set
                {
                    //other custom code goes here
                    base.MyField = value;
                }
            }
        }

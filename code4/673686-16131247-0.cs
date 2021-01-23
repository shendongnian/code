    public override object SaveControlState()
    {
        object obj = base.SaveControlState();
        // Your problem is here
        // return new object[] { obj, Text };
        if (!string.IsNullOrEmpty(Text))
        {
           if (obj != null)
           {
               return new object[] { obj, Text };
           }
           else
           {
               return Text;
           }
        }
        else
        {
            return obj;
        }
    }
    public override void LoadControlState(object state)
    {
        if (state != null)
        {
            object obj = state as object[];
            if (obj != null)
            {
                base.LoadControlState(obj[0]);
                Text = (string)obj[1];
            }
            else
            {
                if (state is string)
                {
                     Text = (string)state;
                }
                else
                {
                     base.LoadControlState(state);
                }
            }
        }
    }

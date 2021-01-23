    public class YourCheckBox:CheckBox
        {
            public event EventHandler<EventArgs> OnCheckedChangedCustom;
    
            protected override void OnCheckedChanged(EventArgs e)
            {
                if (OnCheckedChangedCustom!=null)
                {
                    OnCheckedChangedCustom(this, EventArgs.Empty);
                }
                base.OnCheckedChanged(e);
            }
        }

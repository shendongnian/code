    protected virtual void OnValChanged(int oldvalue, int newvalue)
            {
                if (ValueChanged != null)
                    ValueChanged(this, new ValueChangedEventArgs { OldValue = oldvalue, NewValue = newvalue });
            }
    
    
            public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);
    
            public event ValueChangedEventHandler ValueChanged;

    class ValueChangedEventArgs : EventsArgs
    {
         public readonly int LastValue;
         public readonly int NewValue;
         public ValueChangedEventArgs(int LastValue, int NewValue)
         {
             this.LastValue = LastValue;
             this.NewValue = NewValue;
         }
    }
    class MyClass
    {
         public MyClass(int InitialValue)
         { 
              _value = InitialValue;
         }
   
         public event EventHandler<ValueChangedEventArgs> ValueChanged;
         
         protected virtual void OnValueChanged(ValueChangedEventArgs e)
         {
               if(ValueChanged != null)
                  ValueChanged(this, e);
         }
         private int _value;
         
         public int Value
         {
             get { return _value; }
             set 
             { 
                 OnValueChanged(new ValueChangedEventArgs(_value, value);
                 _value = value; 
             }
         }
    }

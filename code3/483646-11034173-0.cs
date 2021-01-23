        public delegate object GetControlValue(Control aCtrl);
        private static Dictionary<Type, GetControlValue> _valDelegates;
        public static Dictionary<Type, GetControlValue> ValDelegates
        {
            get 
            { 
                if (_valDelegates == null)
                    InitializeValDelegates();
                return _valDelegates; 
            }
        }
        private static void InitializeValDelegates()
        {
            _valDelegates = new Dictionary<Type, GetControlValue>();
            _valDelegates[typeof(TextBox)] = new GetControlValue(delegate(Control aCtrl) 
            {
                return ((TextBox)aCtrl).Text;
            });
            _valDelegates[typeof(CheckBox)] = new GetControlValue(delegate(Control aCtrl)
            {
                return ((CheckBox)aCtrl).Checked;
            });
            // ... other controls
        }
        public static object GetValue(Control aCtrl)
        {
            GetControlValue aDel;
            if (ValDelegates.TryGetValue(aCtrl.GetType(), out aDel))
                return aDel(aCtrl);
            else
                return null;
        }

    public class MyControl : Control
    {
        protected override void CreateChildControls()
        {
            // other controls
        }
        public MyControlValue Value
        {
            get
            {
                var obj = ViewState["Value"];
                return obj != null ? (MyControlValue)obj : MyControlValue.Default();
            }
            set
            {
                ViewState["Value"] = value;
            }
        } 
        
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            var presentValue = JsonConvert.SerializeObject(Value);
            var postedValue = postCollection[postDataKey];
            if (!string.IsNullOrEmpty(presentValue) && !presentValue.Equals(postedValue))
            {
                Value = JsonConvert.DeserializeObject<MyControlValue>(postedValue);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RaisePostDataChangedEvent()
        {
            OnValueChanged(EventArgs.Empty);
        }
        
        #region Event
        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(this, e);
        }
        #endregion Event
        
        [Serializable]
        public class MyControlValue
        {
            public string Prop1 {get; set;}
            public string Prop2 {get; set;}
            public static MyControlValue Default()
            {
                return new MyControlValue
                {
                    Prop1 = "some default value",
                    Prop2 = "999"
                };
            }
        }
    }

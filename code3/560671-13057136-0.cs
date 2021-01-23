        public void SetMyIntValue()
        {
            SetPropertyValue(this, this.GetType().GetProperty("MyInt"));
        }
        public int MyInt { get; set; }
        public void SetPropertyValue(object obj, PropertyInfo pInfo)
        {
            pInfo.SetValue(obj, 5);
        }

        public override string ToString() {
    PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
                StringBuilder builder = new StringBuilder();
                foreach(PropertyDescriptor pd in coll)
                    builder.Append(string.Format("{0} : {1}", pd.Name , pd.GetValue(this).ToString()));
    
                return builder.ToString();
                }

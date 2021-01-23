        public IList<T> RetrieveView<T>(string result)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
    
            IList<T> values = ser.Deserialize< IList<T> >(result);
    
            return values;
        }

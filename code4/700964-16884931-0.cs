        public void GetResponseObj<T>(Func<T, jsonResponseObj> custom, T arg) where T:class
        {
            try
            {
                Data = custom(arg);
            }
            catch (Exception ex)
            {
                // alert elmah
                Data = new jsonResponseObj(ex);
            }
        }

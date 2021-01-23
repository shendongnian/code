        public static bool Run(Action a)
        {
            try
            {
                a();
                return true;
            }
            catch(Exception ex)
            {
                //custom error handling here
                return false;
            }
        }

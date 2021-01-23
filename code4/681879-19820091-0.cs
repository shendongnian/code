        public  string gtresource(string rulename)
        {
            string value = null;
            System.Resources.ResourceManager RM = new System.Resources.ResourceManager("CodedUITestProject1.Resource1", this.GetType().Assembly);
            value = RM.GetString(rulename).ToString();
            if(value !=null && value !="")
            {
                return value;
            }
            else
            {
                return "";
            }
        }

        public string MyParam
        {
               get
               {
                     return Session["MyParamStr"].ToString();
               } 
               set 
               {
                    Session["MyParamStr"] = value;
               }
        }

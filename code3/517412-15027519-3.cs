    [Serializable]
        public class FlatFileItem
        {
            ArrayList errorlist = new ArrayList();
    
            public FlatFileItem()
            {
                if (errorlist == null) { errorlist = new ArrayList(); }
            }
    
            //Name of the file
            public string FileName { get; set; }
            public override string ToString()
            {
                return string.Format(@"FlatFileItem (Unzip FTPLineItem) => FileName:{0}",  this.FileName);
            }
        }
    
    
    public class someclass {
        public void somemethod(){
            try{
                  //Throw exception code
            } catch (Exception ex)
                        {
                            ex.Data["flatfile"] = Convert.ToString(flatfile);  //Using data property
                            flatfile.HasErrors = true;  //not there in above example
                            flatfile.Parent.AddErrorInfo(ex); //not there in above example
                            logger.Error(String.Format(ex.Message)); //not there in above example
    
                            throw ( new Exception ("yourmsg",ex)); //if you want to do this
                        }
        }
    }

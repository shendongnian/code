    public class DupeNVC: NameValueCollection
    {
        private string _duplicateKey;
        public DupeNVC(string duplicateKey = null)
        {
            _duplicateKey = duplicateKey;
        }
        public override string Get(int index)
        {
            //check if duplicate key has been specified
            //if not, then call the default Get implementation
            if (!String.IsNullOrEmpty(_duplicateKey))
            {
                ArrayList list = (ArrayList)base.BaseGet(index);              
                int num = (list != null) ? list.Count : 0;
                if (num == 1)
                {
                    return (string)list[0];
                }
                if (num > 1)
                {
                    StringBuilder stringBuilder = new StringBuilder((string)list[0]);
                 
                    for (int i = 1; i < num; i++)
                    {
                        //format our string and append the duplicate key specified
                        stringBuilder.AppendFormat("&{0}=", _duplicateKey);
                        stringBuilder.Append((string)list[i]);
                    }
                    return stringBuilder.ToString();                   
                }
                return null;
            }
            else
               return base.Get(index);
        }
        
    } 

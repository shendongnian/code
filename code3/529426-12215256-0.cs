    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Collections;
    
    public class BAL
    {
        DAL objDAL;
        public BAL()
        {
    
        }
    
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    
        public int insert()
        {
            objDAL = new DAL();
            int val = 0;
            try
            {
                Hashtable objHash = new Hashtable();
                objHash.Add("@Name", Convert.ToString(_Name));
                val = objDAL.Insert("Your SP Name", objHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDAL = null;
            }
            return val;
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;
    
    namespace mol_intranet
    {
        public class ClassTesting
        {
    
            //pass the fields to be checked/updated here as ref variables
            public void checkFields(ref TextBox loadedby, ref TextBox updatedby)
            {
    
                string ActiveUser = System.Web.HttpContext.Current.User.Identity.Name;
                string LoginID = ActiveUser.Right(6);
    
                var txtLoadedBy_chk = string.IsNullOrEmpty(loadedby.Text);
                if ((txtLoadedBy_chk == true))
                {
                    loadedby.Text = LoginID;
                }
    
                var txtUpdatedBy_chk = string.IsNullOrEmpty(updatedby.Text);
                if ((txtUpdatedBy_chk == true))
                {
                    updatedby.Text = LoginID;
                }
    
            }
        }
    }

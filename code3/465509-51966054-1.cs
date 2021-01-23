    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace NlogWeb
    {
    public partial class Home : System.Web.UI.Page
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Divide By Zero Exception", new DivideByZeroException());
            }
            catch (Exception ex)
            {                 
                logger.Error(ex.Message);
            }
        }
      }
    }

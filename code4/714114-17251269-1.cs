    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Lotto
    {
        public partial class Draw : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
    
            public void LottoTest(object sender, EventArgs e)
            {
                Dictionary<int, int> numbers = new Dictionary<int, int>();
                Random generator = new Random();
                while (numbers.Count < 6)
                {
                    numbers[generator.Next(1, 49)] = 1;
                }
    
                string[] lotto = numbers.Keys.OrderBy(n => n).Select(s => s.ToString()).ToArray();
    
                foreach (String _str in lotto)
                {
                    Response.Write(_str);
                    Response.Write("<br/>");
                }
            }
        }
    }

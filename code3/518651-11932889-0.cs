    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Collections;
    using System.Diagnostics;
    public partial class SessionVarTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string item01 = "Item 1";
          string item02 = "Item 2";
          ArrayList MyArrayIn = new ArrayList();
          MyArrayIn.Add(item01);
          MyArrayIn.Add(item02);
          Session["MyBasket"] = MyArrayIn;
          ArrayList MyArrayOut = (ArrayList)Session["MyBasket"];
          Debug.WriteLine("Content of ArrayList restored from session var");
          Debug.WriteLine("ArrayList item 1: " + MyArrayOut[0]);
          Debug.WriteLine("ArrayList item 2: " + MyArrayOut[1]);
        }
    }

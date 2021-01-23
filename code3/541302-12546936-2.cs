    // MASTER PAGE
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication4
    {
	    public delegate void MyDelegate(object sender, EventArgs e);
	    public partial class SiteMaster : System.Web.UI.MasterPage
	    {
		    // Here I am declaring the instance of the control...I have put it here to illustrate
		    // but normally you have dropped it onto your form in the designer...
		    protected WebUserControl1 ctrl1;
		    protected void Page_Load(object sender, EventArgs e)
		    {
			    // instantiate user control...this is done automatically in the designer.cs page 
			    // if you created it in the visual designer...
			    this.ctrl1 = new WebUserControl1();
			    // start listening for the event...
			    this.ctrl1.OnSomethingHappened += new MyDelegate(ctrl1_OnSomethingHappened);
		    }
		    void ctrl1_OnSomethingHappened(object sender, EventArgs e)
		    {
			    // here you react to the event being fired...
			    // perhaps you have "sent" yourself something as an object in the 'sender' parameter
			    // or perhaps you have declared a delegate that uses your own custom EventArgs...
		    }
	    }
    }
    //WEB USER CONTROL
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace WebApplication4
    {
	    public partial class WebUserControl1 : System.Web.UI.UserControl
	    {
		    public event MyDelegate OnSomethingHappened;
		    protected void Page_Load(object sender, EventArgs e)
		    {
		    }
		    private void MyMethod()
		    {
			    // do stuff...then fire event for some reason...
			    // Incidentally, ALWAYS do the != null check on the event before
			    // attempting to launch it...if nothing has subscribed to listen for the event
			    // then attempting to reference it will cause a null reference exception.
			    if (this.OnSomethingHappened != null) { this.OnSomethingHappened(this, EventArgs.Empty); }
		    }
	    }
    }

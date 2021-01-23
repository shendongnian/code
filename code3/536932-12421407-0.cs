    public partial class A: System.Web.UI.Page{    
    	private Item item = new Item();//I have a class Item  
    	Session["myItem"]=myItem;   
    	protected  void btn1_Click(Object sender,EventArgs e)
    	    {       Response.Redirect("nextpage.aspx");
    		//Here I want to send item object to the nextpage
    	    }
     }
    
    public partial class nextpage: System.Web.UI.Page{
         Item myItem;
         protected void Page_Load(object sender, EventArgs e)
         {
            myItem =(Cast to It's Type) Session["myItem"];
         }
    } 

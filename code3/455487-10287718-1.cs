    // store the list in the session
    List<string> code=new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
    Session["codeList"]=code;
    }
     // use the list
    void fn()
    {
     code=List<string>(Session["codeList"]); // downcast to List<string> 
     code.Add("some string"); // insert in the list
     Session["codeList"]=code; // save it again
    }

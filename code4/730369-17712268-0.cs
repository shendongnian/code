        <form id="form1" runat="server">
        <div>
        <asp:TextBox ID="txt" runat="server"></asp:TextBox>
        <asp:CheckBox ID="cb" runat="server"></asp:CheckBox>
        </div>
        </form>
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	var controls = form1.Controls;
    	var tbCount = 0;
    	var cbCount = 0;
    	CountControls(ref tbCount, controls, ref cbCount);
    
    	Response.Write(tbCount);
    	Response.Write(cbCount);
    }
    
    private static void CountControls(ref int tbCount, ControlCollection controls, ref int cbCount)
    {
    	foreach (Control wc in controls)
    	{
    		if (wc is TextBox)
    			tbCount++;
    		else if (wc is CheckBox)
    			cbCount++;
    		else if(wc.Controls.Count > 0)
    			CountControls(ref tbCount, wc.Controls, ref cbCount);
    	}
    }

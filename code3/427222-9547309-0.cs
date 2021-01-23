    protected string GetText(object oItem)
    {
        if(txtSearchForMe.Text.Lenght > 0)
        {
        	return DataBinder.Eval(oItem, "cText").Replace(txtSearchForMe.Text, "<b>" + txtSearchForMe.Text + "</b>");
        }
        else
        {
        	return DataBinder.Eval(oItem, "cText");
        }        
    }

    protected void FinalizeNewCar(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in ImageRepeater.Items)
        {
            Int32 imageId = Convert.ToInt32(((HiddenField) item.FindControl("txtImageId")).Value);
            string description = ((TextBox)item.FindControl("txtText")).Text;
            //You will get the imageId description here. 
            //Write your code to update the datatbase.
        }
    }

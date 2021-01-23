    #define DEBUG
    public class YourClass 
    {
        POrder po = new POrder();          
        po.PODate = DateTime.Parse(txtPODate.Text);
        Break point here ->
        
        po.POVendorID = int.Parse(ddPOVendors.SelectedValue);
        #if (!DEBUG)
            po.AddNewOrder(); //this will not be executed during debug.
        #endif
        ....      
    }

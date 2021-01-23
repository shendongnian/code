    public class Vendor{
        public int VendorId {get; set;}
        public string VendorName {get; set;}
    }
    // Inside your function
       var comboboxData = new List<Vendor>(){
           new Vendor(){ vendorId = 1, vendorName = "Vendor1" },
           new Vendor(){ vendorId = 2, vendorName = "Vendor2" }
       }
       cmbVendor.DataSource = comboboxData;
       cmbVendor.DisplayMember = "VendorName";
       cmbVendor.ValueMember = "ValueId";
    // Now, to change your selected index to the ComboBox item with ValueId of 2, you can simply do:
       cmbVendor.SelectedValue = 2;

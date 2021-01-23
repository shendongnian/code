    public delegate void AddressForServiceHandler(string callType, string refreshType, Dictionary<string, string> keyvalues);
    public event AddressForServiceHandler PostalCodeChanged;
    
    protected void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
                Dictionary<string, string> Params = new Dictionary<string, string>();
                Params.Add("PostalCode", txtPostalCode.Text.Trim());
    
                if (PostalCodeChanged != null)
                {
                    PostalCodeChanged(txtPostalCode.Text, "PostalCode", Params);
                }
        }

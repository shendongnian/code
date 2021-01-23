    enum ParamStyle { AddWithValue, AddIntegers, AddVarChar }
    private const int ITEMID_INDEX = 0;
    private const int PACKSIZE_INDEX = 1;
    private const string SQL_CONN_STR = "Data Source=\\badPlace2B\\CCRDB.SDF";
    private const string SQL_GET_VENDOR_ITEMS = "SELECT ItemID, PackSize FROM VendorItems WHERE VendorID=@VendorID AND VendorItemID=@VendorItemID";
    private bool PopulateControlsIfVendorItemsFound(ParamStyle style) {
      bool recordFound = false;
      //DUCKBILL.LogMsgs.Append("Made it into frmEntry.PopulateControlsIfVendorItemsFound()\r\n");
      string itemID = null;
      string packSize = null;
      //string vendorId = txtVendor.Text.Trim();
      //string vendorItemId = txtUPC.Text.Trim();
      //string query = string.Format("SELECT ItemID, PackSize FROM VendorItems WHERE VendorID = {0} AND VendorItemID = {1}", vendorId, vendorItemId);
      //if (dbconn.isValidTable("VendorItems") == -1) {
      //  DUCKBILL.LogMsgs.Append("VendorItems not a valid table");//do not see this msg; good! VendorItems is seen as valid...
      //  return false;
      //}
      using (var cmd = new SqlCeCommand(SQL_GET_VENDOR_ITEMS, new SqlCeConnection(SQL_CONN_STR))) {
        // cmd.CommandType = CommandType.Text; (this is the default)
        if (style == ParamStyle.AddIntegers) { // Adding Integers:
          cmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = Convert.ToInt32(txtVendor.Text.Trim());
          cmd.Parameters.Add("@VendorItemID", SqlDbType.Int).Value = Convert.ToInt32(txtUPC.Text.Trim());
        } else if (style == ParamStyle.AddVarChar) { // Adding String Values
          // NOTE: Here, you should look in your database table and
          // use the size you defined for your VendorID and VendorItemID columns.
          cmd.Parameters.Add("@VendorID", SqlDbType.VarChar, 25).Value = txtVendor.Text.Trim();
          cmd.Parameters.Add("@VendorItemID", SqlDbType.VarChar, 50).Value = txtUPC.Text.Trim();
        } else if (style == ParamStyle.AddWithValue) { // Adding as Objects (only if you don't know what the data types are)
          cmd.Parameters.AddWithValue("@VendorID", txtVendor.Text.Trim());
          cmd.Parameters.AddWithValue("@VendorItemID", txtUPC.Text.Trim());
        }
        try {
          cmd.Connection.Open();
          using (var myReader = cmd.ExecuteReader(CommandBehavior.SingleRow)) {
            if (myReader.Read()) {
              itemID = myReader.GetString(ITEMID_INDEX);
              packSize = myReader.GetString(PACKSIZE_INDEX);
              recordFound = true;
            }
          }
        } catch (SqlCeException err) {
          //DUCKBILL.LogMsgs.Append(string.Format("Exception in PopulateControlsIfVendorItemsFound: {0}\r\n", err.Message));
          // (I never return from a 'catch' statement) return recordFound;
        } finally {
          if (cmd.Connection.State == ConnectionState.Open) {
            cmd.Connection.Close();
          }
        }
      }
      if (recordFound) { // set these last, and set them OUTSIDE of the try/catch block
        txtID.Text = itemID;
        txtSize.Text = packSize;
      }
      return recordFound;
    }

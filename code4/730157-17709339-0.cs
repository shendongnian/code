    public class YourClass {
        private DropDownList ddl;
        private TestBox txa;
        private void createControls {
            // ...
            TextBox txa = new TextBox();
            txa.ID = "amtData" + rowcount.ToString();
            // ...
            DropDownList ddl = new DropDownList();
            ddl.Items.Add("No Change");
            // ... etc.
        }
        void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl.SelectedIndex == 1)
                txa.Enabled = true;
        }
    }

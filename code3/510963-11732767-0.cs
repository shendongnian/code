    class ChildForm : Form {
        private Inventory _inventory;
        public Inventory MyInventory {
            get {
                return _inventory;
            }
        }
        private void btnAccept_Click(object sender, EventArgs e) {
            _inventory = <set_inventory_here>;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }

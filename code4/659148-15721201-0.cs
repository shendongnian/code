    private void lsvproccess_SelectedIndexChanged(object sender, EventArgs e)
    {
        lsvitems.Items.Clear();
        ListView lsvview = new ListView();
        if (lsvview.FocusedItem != null) { // <-- google "C# null reference"
            int index = lsvview.FocusedItem.Index;
    
            Process p = new Process();
            p = (Process)process_array[index];
        
            Detail_process(p);    // detailing each process in right side listview
            try
            {
                // calling Get_modules() method to acquire whole modules 
                // cooperating in this process
                if (chbxmodule.Checked)
                    Get_modules(p.Modules);
            }
            catch (Win32Exception err)
            {
                MessageBox.Show(err.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

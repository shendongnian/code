    public void whateverToolStripMenuItem_Click(object sender, EventArgs e) {
    // A previously declared and instantiated OpenFileDialog, i put it from Design Mode, but you can just
    // declare it as 
    OpenFileDialog dlgImport = new OpenFileDialog();
    //We show the dialog:
    dlgImport.ShowDialog();
    // We declare a variable to store the file path and name:
    string fileName = dlgImport.FileName;
    try {
        // We invoke our method, wich is created in the following section, and pass it two parameters
        // The file name and .... a DataGridView name that we put is the Form, so we can also see what
        // We imported. Cool, isn't it?
        importExcel(fileName, gridMain);
    }
    // It is best to always try to handle errors, you will se later why it is OleDbException and not
    catch (OleDbException ex) {
        MessageBox.Show("Error ocurred: " + ex.Message);
    }
}

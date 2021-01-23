    private void button_Click(object sender, EventArgs e)
    {
    try
    {
        DialogResult result;
        DataGrid.visible=false;
        result = MessageBox.Show( "Questa operazione potrebbe richiedere alcuni minuti,\r\nsei sicuro di voler continuare?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
        if ( result == System.Windows.Forms.DialogResult.Yes )
        {
            DoSomething();
        }
        else
        {
            DoSomethingElse();
        }
    }
    DataGrid.visible=true;
    Catch (Exception ex)
    {
        LogExceptio(ex);
    }
    } 

    class MyDataGrid : System.Windows.Forms.DataGrid
    {
       protected override bool ProcessCmdKey(ref Message msg, Keys keyData)	
       {
                const int WM_KEYDOWN = 0x100;
                const int WM_SYSKEYDOWN = 0x104;
                if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
                {
                    switch (keyData)
                    {
                        case Keys.Shift | Keys.Delete:
                            MessageBox.Show("shift + del pressed");
                            break;
                    }
                }
                return base.ProcessCmdKey(ref msg, keyData);
       }
    }	

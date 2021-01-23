    public void Button_Click(Microsoft.Office.Core.IRibbonControl ctrl)
    {
            switch (ctrl.Id)
            {
                case "MyMenuItem": System.Windows.Forms.MessageBox.Show("MyMenuItem"); break;
            }
    }

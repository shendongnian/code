    //you can use DialogResult  object to know to other form is closed
    // DialogResult dlgResult = DialogResult.None;
    
    public void openFullScreen(String id,String content)
    {
          DialogResult dlgResult = DialogResult.None;  
         
        frmEditor Editor = new frmEditor();`enter code here`
        Editor.WindowState = FormWindowState.Maximized;
        Editor.Content = content;
        Editor.ID = id;
        dlgResult=Editor.ShowDialog();
          if (dlgResult == System.Windows.Forms.DialogResult.OK)
          { 
                   // code that you will execute after Editor form is closed
          }
    
    }
    
    
    
    private void btnClose_Click(object sender, EventArgs e)
    {
        Object content = browserEditor.Document.InvokeScript("getContent");
        if (content != null)
        {
            object[] args = new object[2];
            args[0] = content.ToString();
            args[1] = _id;
            AppDomain.CurrentDomain.SetData("EditorContent", args);
    
       /* use:  this.DialogResult = System.Windows.Forms.DialogResult.OK;   instead of this.close */
            this.DialogResult = System.Windows.Forms.DialogResult.OK;//this.Close();
            //browserEditor.Document.InvokeScript("setEditorContent",args)
        }
    }

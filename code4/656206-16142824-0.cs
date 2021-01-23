    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
                NodeClick(e.Node.Tag as Form);
            }
    public void NodeClick(Form theForm)
    {
       if(theForm == null) return;
       if(theForm.Visible == false)
       {
            theForm .Show(this);
       }
       theForm .Activate();
       theForm .WindowState = FormWindowState.Normal;
       theForm .BringToFront();
    }

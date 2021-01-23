    TreeNode treeNode4 = new TreeNode("Importação CT-I", array5);
    treeView1.Nodes.Add(treeNode4);
    
    TreeNode nodeusu1 = new TreeNode("Usuários");
    TreeNode nodeusu2 = new TreeNode("Servers");
    TreeNode nodeusu3 = new TreeNode("Permissões");
    TreeNode nodeusu4 = new TreeNode("Alterar Senha");
    TreeNode nodeusu5 = new TreeNode("Sobre");
    TreeNode nodeusu6 = new TreeNode("Encerrar");
    TreeNode[] array6 = new TreeNode[] { nodeusu1, nodeusu2, nodeusu3, nodeusu4, nodeusu5, nodeusu6 };
    
    Conecta Servidor = null;
    
    
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (treeView1.SelectedNode.Text == "Grupo")
        {
            frm_grupo grupo = new frm_grupo();
            grupo.TopLevel = false;
            grupo.AutoScroll = true;
            panelmain.Controls.Add(grupo);
            grupo.Show();
        }
    
        else if (treeView1.SelectedNode.Text == "Servers")
        {
            if(Servidor == null)
            {
                Servidor = new Conecta();
                Servidor.TopLevel = false; 
                Servidor.AutoScroll = true;
                Servidor.Closed += new FormClosedEventHandler(ServidorClosed);
            }
            Servidor.Show();
                Servidor.BringToFront();
        }
    }
    private void ServidorClosed(object sender, EventArgs e)
    {
        if(Servidor != null)
            Servidor.Dispose();
        Servidor == null;
    }

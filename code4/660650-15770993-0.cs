     private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
                treeView1.SelectedNode = e.Node;
                string args = string.Format("/Select, {0}", treeView1.SelectedNode.Text);
    
                ProcessStartInfo process= new ProcessStartInfo("explorer.exe", args);
                System.Diagnostics.Process.Start(process);
            }

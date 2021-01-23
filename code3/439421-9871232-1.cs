    OpenFileDialog dlg = new OpenFileDialog();
        dlg.Title = "Open XML document";
        dlg.Filter = "XML Files (*.xml)|*.xml";
        dlg.FileName = Application.StartupPath + "\\..\\..\\Sample.xml";
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                //Just a good practice -- change the cursor to a 
                //wait cursor while the nodes populate
                this.Cursor = Cursors.WaitCursor;
                //First, we'll load the Xml document
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(dlg.FileName);
                //Now, clear out the treeview, 
                //and add the first (root) node
                treeView1.Nodes.Clear();
                TreeNode rootTreeNode = new TreeNode(xDoc.DocumentElement.Name);
                treeView1.Nodes.Add(rootTreeNode);
                foreach (XmlNode titleNode in xDoc.DocumentElement.SelectNodes(@"//title"))
                {
                    rootTreeNode.Nodes.Add(titleNode.InnerText);
                }
                treeView1.ExpandAll();
            }
            catch (XmlException xExc)
            //Exception is thrown is there is an error in the Xml
            {
                MessageBox.Show(xExc.Message);
            }
            catch (Exception ex) //General exception
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default; //Change the cursor back
            }
        }}

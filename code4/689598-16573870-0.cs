     private void treelocations_MouseClick(object sender, MouseEventArgs e)
     {
          switch(e.Button)
          {
              case MouseButtons.Right:
              {
                  Point pos = new Point();
                  pos.X = e.X;
                  pos.Y = e.Y;
                  treeView1.Focus();
                  MessageBox.Show(treelocations.SelectedNode.Text);
                  break;
               }
          }
     }

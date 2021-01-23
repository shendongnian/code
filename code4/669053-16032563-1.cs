        private void tablelayout_MouseClick(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            
            if (e.Button == MouseButtons.Right)
            {
                h = l;
                num = l.Text;
                m.MenuItems.AddRange(new MenuItem[] { addDevice, deleteDevice, fire, fault,suppress  });
                tableLayout.ContextMenu = m;
                m.Show((Control)(sender), e.Location);
            }           
            
        }

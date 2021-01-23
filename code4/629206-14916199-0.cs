    private void listBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            {
                if (index == listBox1.SelectedIndex)
                {
                    listboxContextMenu.Show(listBox1, listBox1.PointToClient(System.Windows.Forms.Cursor.Position));
                }
            }
        }
    }
     

    private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds
            ToolTip tt = new ToolTip();
            tt.Show("Test ToolTip",TB,TB.Location.X + TB.Width,TB.Location.Y,VisibleTime);
        }

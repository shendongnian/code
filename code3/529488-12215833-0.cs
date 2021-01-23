        //Here you add event to button
        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is Button)
            {
                Button btn = e.Control as Button;
                btn.Click -= new EventHandler(btn_Click);
                btn.Click += new EventHandler(btn_Click);
            }
        }
 
        void btn_Click(object sender, EventArgs e)
        {
            if(sender is button)
                ((button)sender).Text = "new text";
        }

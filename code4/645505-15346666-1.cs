     private bool _changePost;
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            var view = sender as DataGridView;
            var bs = bindingSource1;
            if (e.KeyData == Keys.Up)
            {
                if (bs.Position == 0 && _changePost)
                {
                    _changePost = false;
                    bs.MoveLast();
                }
                if (bs.Position == 0 && !_changePost)
                    _changePost = true;
    
            }
            else if (e.KeyData == Keys.Down)
            {
                if (bs.Position == bs.Count - 1 && _changePost)
                {
                    bs.MoveFirst();
                    _changePost = false;
                }
                if (bs.Position == bs.Count - 1 && !_changePost)
                    _changePost = true;
            }
        }

        void browser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.N || e.KeyCode == Keys.O) && e.Control)
            {
                e.IsInputKey = true;
            }
        }

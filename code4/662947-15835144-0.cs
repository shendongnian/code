        //in UserControl
        public event EventHandler Selected;
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(Selected!=null)
                Selected(this,null);
        }

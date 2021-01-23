            int CurrentIndex;
            private void textNumber_Click(object sender, EventArgs e)
            {
                CurrentIndex = textNumber.SelectionStart;
            }
    
            private void Key_Click(object sender, EventArgs e)
            {
                textNumber.Text = textNumber.Text.Insert(CurrentIndex, "_");
            }

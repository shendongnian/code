        private void MySampleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //get control hovered with mouse
                Button buttonToRemove = (this.GetChildAtPoint(this.PointToClient(Cursor.Position)) as Button);
                //if it's a Button, remove it from the form
                if (buttonToRemove != null)
                {
                    this.Controls.Remove(buttonToRemove);
                }
            }
        }

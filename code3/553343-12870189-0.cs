        private void btnThatGetsClicked_Click(object sender, EventArgs e)
        {
            //Remove the existing controls.
            this.Controls.Remove(this.textBox1);
            this.Controls.Remove(this.textBox2);
            this.Controls.Remove(this.btnThatGetsClicked);
            //Create the new controls.
            TextBox TextBox_New = new TextBox();
            Button Button_New = new Button();
            //Add the new controls to this form.
            this.Controls.Add(TextBox_New);
            this.Controls.Add(Button_New);
        }

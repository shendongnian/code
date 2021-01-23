         int checkWidth = CheckBoxRenderer.GetGlyphSize(yourCheckBox.CreateGraphics(),System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal).Width;
         //TextChanged event handler of your CheckBoxes (used for all the checkBoxes)
         private void checkBoxes_TextChanged(object sender, EventArgs e){
           UpdateCheckBoxSize((CheckBox)sender);
         }
         //method to update the size of CheckBox, the size is changed when the CheckBox's Font is bolded and AutoSize = true.
         //However we set AutoSize = false and we have to make the CheckBox wide enough
         //to contain the bold version of its Text.
         private void UpdateCheckBoxSize(CheckBox c){
            c.Width = TextRenderer.MeasureText(c.Text, new Font(c.Font, FontStyle.Bold)).Width + 2 * checkWidth;
         }
         //initially, you have to call UpdateCheckBoxSize
         //this code can be placed in the form constructor
         foreach(CheckBox c in tableLayoutPanel1.Controls.OfType<CheckBox>())
            UpdateCheckBoxSize(c);
         //add this to make your CheckBoxes centered even when the form containing tableLayoutPanel1 resizes
         //This can also be placed in the form constructor
         tableLayoutPanel1.Parent.SizeChanged += (s,e) => {
            tableLayoutPanel1.Left = (tableLayoutPanel1.Parent.Width - tableLayoutPanel1.Width)/2;
         };

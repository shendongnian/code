    foreach (Control ctrl in placeHolder.Controls)
    {
        if (ctrl is Panel)
        {
            // Get each ID and Text from TextBox
            var textBoxes = ctrl.Controls.OfType<TextBox>()
                                         .Select(t => Tuple.Create(t.ID, t.Text));
            
            foreach(var item in textBoxes)
            {
                //do whatever
            }
        }
    }

    using (Form1 form = new Form1())
    {
        bool valid = false;
        var result = DialogResult.OK;
        while(!valid && result == DialogResult.OK)
        {
            // I can call ShowDialog multiple times without having to create new
            //   instances of my Form1 class.
            result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var formData = form.GetFormData(); // some method to get the form data
                valid = ValidateFormData(formData);
            }
        }
    }

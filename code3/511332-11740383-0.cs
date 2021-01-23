     const string message =
            "message";
        const string caption = "your test";
        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
    
        // If the no button was pressed ...
        if (result == DialogResult.No)
        {
            // cancel the closure of the form.
            e.Cancel = true;
        }

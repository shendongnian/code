    foreach (Control c in this.Controls) {
        if (c is Panel) {
            MessageBox.Show("Hey, I found the " + c.Name + " panel!");
        }
    }

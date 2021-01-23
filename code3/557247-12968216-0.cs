    private void contactButton_Click(object sender, EventArgs e)
    {
        if (contactForm == null)
        {
           contactForm = new ContactForm();
           contactForm.FormClosing += new FormClosingEventHandler(contactForm_FormClosing);
        }
        contactForm.Show();
    }

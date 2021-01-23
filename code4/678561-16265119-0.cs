        ticketTypesForm myTicketTypesForm;
        private void OpenDialog(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ticketTypesForm>().Any())
            {
                if (myTicketTypesForm == null)
                    myTicketTypesForm = new ticketTypesForm();
                myTicketTypesForm.Show();
            }
            else
            {
                myTicketTypesForm.Focus();
            }
        }

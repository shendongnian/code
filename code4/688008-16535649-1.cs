    private void btnOK_BS__Spec_Click(object sender, EventArgs e)
    {
       
        string spec = cboIT_Spec.Text;
    
        do
        {
            if (spec == "Animation and Game Development" || spec == "Digital Arts")
            {
                result.setSpec(spec);
                MessageBox.Show("You chose " + result.getSpec() + ".", "Specialization",
                MessageBoxButtons.OK, MessageBoxIcon.Information);     
            }
            else
            {
                MessageBox.Show("Please select your Specialization.");
            }
        }
        while (result.getSpec() == "");
    }

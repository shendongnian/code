    private void cmbxVariables_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbxVariables.Text == New_Variable)
            {
                try
                {
                    DtsContainer dtsContainer = null;
                    dtsVariableServie = serviceProvider.GetService(typeof(IDtsVariableService)) as IDtsVariableService;
                    Variable var = dtsVariableServie.PromptAndCreateVariable(null, dtsContainer, "VariableName", "User", typeof(string));
                    if (!var.IsNull())
                    {
                        cmbxVariables.DataSource = null;
                        cmbxVariables.DataSource = FillVariableList();
                    }
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }
            else
            {
                foreach (Variable v in thetaskHost.Variables)
                {
                    if (v.Name == cmbxVariables.Text)
                    {
                        //Do something with the variable selected
                        break;
                    }
                }
            }          
        }

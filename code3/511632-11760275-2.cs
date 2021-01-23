    protected void intValidate_Validate(object sender, ServerValidateEventArgs arg)
    {
        if (args.Value.Length > 0)
        {
            int num;
            arg.IsValid = int.TryParse(are.Value, out num);
        }
        else
        {
            arg.IsValid = true;
        }
    }

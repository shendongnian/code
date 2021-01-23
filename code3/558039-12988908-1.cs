        protected void CustomValidatorDate1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Value))
            {
                DateTime d = new DateTime();
                if (!DateTime.TryParse(args.Value, out d))
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

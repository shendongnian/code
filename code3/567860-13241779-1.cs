        protected void DateTimeCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
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

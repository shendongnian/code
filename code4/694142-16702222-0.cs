    public class Validator
    {
        public bool ValidateAsInt(Control control)
        {
            bool valid = true;
            if (control.GetType() == typeof(TextBox))
            {
                int outVal = 0;
                if (0 == int.TryParse(((TextBox)control).Text, outVal))
                {
                    valid = false;
                }
            }
            if (valid)
            {
                foreach (Control childControl in control.Controls)
                {
                    if (!ValidateAsInt(childControl))
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }
    }

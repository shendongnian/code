       protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
                {
                    if (TextBox2.Text.Length > TextBox1.Text.Length)
                        args.IsValid = false;
                    else
                        args.IsValid = true;
                }

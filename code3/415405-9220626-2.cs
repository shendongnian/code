       protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
                {
                    if (TextBox1.Text.Length > TextBox2.Text.Length)
                        args.IsValid = false;
                    else
                        args.IsValid = true;
                }

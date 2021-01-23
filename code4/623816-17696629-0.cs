        dynamic document = (JSObject)webControl.ExecuteJavascriptWithResult("document");
    using (document)
                    {
                        try
                    {
                        dynamic email = document.getElementById("email");
                        dynamic password = document.getElementById("password");
                        if (email == null && password == null)
                            return;
                        using (email)
                        {
                            email.value = "abc@msn.com";
                        }
                        using (password)
                        {
                            password.value = "password";
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

            MethodInfo mi = myTextBox.GetType().GetMethod("OnTextChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            try
            {
                mi.Invoke(myTextBox, new object[] { EventArgs.Empty });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
            }

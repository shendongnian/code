    /// <summary>
        /// Starts the new customer.
        /// </summary>
        /// <param name="param">The param.</param>
        public static void StartNewCustomer(Parameter param)
        {
            string windowName = "New Customer";
            if (!IfApplicationWindowOpen(windowName))
            {
                GlobalFactory globalfactory = param.GlobalFactory;
                try
                {
                    Generic objNewCustomer = new Generic();
                    objNewCustomer.StartNewCustomerFromCustomer(param);
                }
                catch (TypeInitializationException tx)
                {
                    globalfactory.ErrorHandler.Log(tx, (int)msmsError.ErrorSeverity.Major | (int)msmsError.ErrorSeverity.User);
                }
                catch (Exception ex)
                {
                    globalfactory.ErrorHandler.Log(ex, (int)msmsError.ErrorSeverity.Major | (int)msmsError.ErrorSeverity.User);
                }
            }
            else
            {
                MessageBox.Show("The application " + windowName + " is already open", windowName + ": Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

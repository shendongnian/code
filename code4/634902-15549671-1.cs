    public void Do()
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    if (string.IsNullOrEmpty(txtPassword.Password))
                    {
                        var view = new LoadingViewControl(txtUserName.Text, txtPassword.Password);
                        result = view.ShowDialog();
                        if (result == true)
                        {
                            ServiceLocator.Current.GetInstance<ContainerViewModel>().ExecuteLobbyBasicViewCommand();
                            PopUp objpopup = new PopUp();
                            objpopup.txtNotice.Text = "sign in";
                            objpopup.txtMessage.Text = "successfully sign in.";
                            objpopup.ShowDialog();
                            Global.GetUserName = txtUserName.Text;
                        }
                        else
                        {
                            //MessageBox.Show("Sign In was unsuccessful. Please correct the errors and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            PopUp objPopUp = new PopUp();
                            objPopUp.txtNotice.Text = "Error";
                            objPopUp.txtMessage.Text = "Sign In was unsuccessful. Please correct the errors and try again.";
                            objPopUp.ShowDialog();
                            txtUserName.Focus();
                            stackpanelLoading.Visibility = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        PopUp objPopUp = new PopUp();
                        objPopUp.txtNotice.Text = "Error";
                        objPopUp.txtMessage.Text = "Please enter the valid Password.";
                        objPopUp.ShowDialog();
                        txtPassword.Focus();
                        stackpanelLoading.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    PopUp objPopUp = new PopUp();
                    objPopUp.txtNotice.Text = "Error";
                    objPopUp.txtMessage.Text = "Please enter the valid Player ID.";
                    objPopUp.ShowDialog();
                    txtUserName.Focus();
                    stackpanelLoading.Visibility = Visibility.Hidden;
                }
            }

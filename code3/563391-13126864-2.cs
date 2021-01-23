        private void OpenDlg()
        {
            opn.Description = "Escolha de diretório:";
            opn.ShowNewFolderButton = false;
            opn.RootFolder = System.Environment.SpecialFolder.MyComputer;
            try
            {
                DialogResult d = opn.ShowDialog();
                if (d == DialogResult.OK)
                {
                    if (opn.SelectedPath != "")
                        UpdateStatus(opn.SelectedPath);
                }
            }
            catch (InvalidCastException erro)
            {
                //When work in main with MTA everytime i get that exception with dialog result
                if (opn.SelectedPath != "")
                    UpdateStatus(opn.SelectedPath);
            }
            catch (Exception er)
            {
            }
            opn.Dispose();
            opn = null;
            runningThread.Join();
        }
        void UpdateStatus(string value)
        {
            if (txtBox.InvokeRequired)
            {
                //Call the delegate for this component.
                txtBox.Invoke(new ModifyTextBox(UpdateStatus), new object[] { value });
                return;
            }
            txtBox.Text = value;
        }

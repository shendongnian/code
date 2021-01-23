    public static class ExtensionsRadForm
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint msg);
        public static void Deminimize(this RadForm form)
        {
            if (form.WindowState == FormWindowState.Minimized)
                ShowWindow(form.Handle, 9);
        }
    }
        private void RefreshButtonsChecks(string windowName)
        {
            if (windowName != null)
            {
                principalPanel.Controls[windowName].BringToFront();
            }
            if (principalPanel.Controls.Count > 0)
            {
                if (principalPanel.Controls.Cast<RadForm>().Any(radForm => radForm.WindowState != FormWindowState.Minimized))
                {
                    foreach (RadItem item in radRibbonBarGroupOpenWindows.Items)
                    {
                        var buttonBorder = ((RadButtonElement) item).BorderElement;
                        if (item.Name == panelPrincipal.Controls[0].Name + "Button")
                        {
                            buttonBorder.ForeColor = Color.LimeGreen;
                            buttonBorder.BottomColor = Color.LimeGreen;
                            buttonBorder.TopColor = Color.LimeGreen;
                            buttonBorder.LeftColor = Color.LimeGreen;
                            buttonBorder.RightColor = Color.LimeGreen;
                            principalPanel.Controls[0].Focus();
                        }
                        else
                        {
                            buttonBorder.ForeColor = Color.Transparent;
                            buttonBorder.BottomColor = Color.Transparent;
                            buttonBorder.TopColor = Color.Transparent;
                            buttonBorder.LeftColor = Color.Transparent;
                            buttonBorder.RightColor = Color.Transparent;
                        }
                    }
                }
                else
                {
                    foreach (RadItem item in radRibbonBarGroupAbiertas.Items)
                    {
                        var buttonBorder = ((RadButtonElement)item).BorderElement;
                        buttonBorder.ForeColor = Color.Transparent;
                        buttonBorder.BottomColor = Color.Transparent;
                        buttonBorder.TopColor = Color.Transparent;
                        buttonBorder.LeftColor = Color.Transparent;
                        buttonBorder.RightColor = Color.Transparent;
                    }
                }
            }
        }
    private void PrincipalPanelLayout(object sender, LayoutEventArgs e)
        {
            RefreshButtonsChecks(null);
        }
    private void RadButtonElementCloseAllWindowsClick(object sender, EventArgs e)
        {
            int limitButtons = radRibbonBarGroupOpenWindows.Items.Count;
            for (int index = 0; index < limitButtons; index++)
            {
                RadItem radItem = radRibbonBarGroupOpenWindows.Items[0];
                radItem.Dispose();
            }
            int limitControls = principalPanel.Controls.Count;
            for (int index = 0; index < limitControls; index++)
            {
                Control control = principalPanel.Controls[0];
                control.Dispose();
            }
            Update();
            GC.Collect();
        }
    private void AddRadFormWindow(Type windowToAdd)
        {
            if (!principalPanel.Controls.ContainsKey(windowToAdd.Name))
            {
                var window = (RadForm) Activator.CreateInstance(windowToAdd);
                window.TopLevel = false;
                window.Visible = true;
                window.FormClosing += (method, args) =>
                                           {
                                               radRibbonBarGroupOpenWindows.Items[window.Name + "Button"].Dispose();
                                               GC.Collect();
                                           };
                window.Enter += (method, args) => RefreshButtonsChecks(window.Name);
                var closeMenuItem = new RadMenuItem("Close");
                closeMenuItem.MouseDown += (method, args) =>
                                               {
                                                   panelPrincipal.Controls[window.Name].Dispose();
                                                   radRibbonBarGroupOpenWindows.Items[window.Name + "Button"].Dispose();
                                               };
                var contextMenu = new RadContextMenu();
                contextMenu.Items.Add(closeMenuItem);
                var button = new RadButtonElement(window.Text) {Name = window.Name + "Button"};
                button.MouseDown += (method, args) =>
                                        {
                                            switch (args.Button)
                                            {
                                                case MouseButtons.Left:
                                                    if (((RadForm) principalPanel.Controls[window.Name]).WindowState ==
                                                        FormWindowState.Minimized)
                                                        ((RadForm) principalPanel.Controls[window.Name]).Deminimize();
                                                    principalPanel.Controls[window.Name].BringToFront();
                                                    principalPanel.Controls[window.Name].Focus();
                                                    break;
                                                case MouseButtons.Right:
                                                    contextMenu.Show(MousePosition);
                                                    break;
                                            }
                                        };
                radRibbonBarGroupOpenWindows.Items.Add(button);
                principalPanel.Controls.Add(window);
            }
            principalPanel.Controls[windowToAdd.Name].BringToFront();
            principalPanel.Controls[windowToAdd.Name].Focus();
            Update();
            GC.Collect();
        }
    public Constructor()
        {
            panelPrincipal.Layout += PanelPrincipalLayout;
        }

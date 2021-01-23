    public void AuthInProxyWindow (string login, string pass)
        {
            var proxyWindow = AutomationElement.RootElement
                .FindFirst(TreeScope.Subtree,
                    new PropertyCondition(AutomationElement.ClassNameProperty, "MozillaDialogClass"));
            var edits = proxyWindow.FindAll(TreeScope.Subtree,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            var unamePoint = edits[1].GetClickablePoint();
            Mouse.MoveTo(new Point((int) unamePoint.X, (int) unamePoint.Y));
            Mouse.Click(MouseButton.Left);
            SendKeys.SendWait(login);
            var pwdPoint = edits[2].GetClickablePoint();
            Mouse.MoveTo(new Point((int) pwdPoint.X, (int) pwdPoint.Y));
            Mouse.Click(MouseButton.Left);
            SendKeys.SendWait(pass);
            Keyboard.Press(Key.Return);
            Logger.Debug("Authefication in Firefox completed succesfully");
        }

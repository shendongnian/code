    using System.Windows.Automation;
    using System.Linq;
    using WatiN.Core.DialogHandlers;
    using WatiN.Core.Native.Windows;
    
    namespace DialogHandlers
    {
        public class Windows7LogonDialogHandler : LogonDialogHandler
        {
            #region Private Fields
    
            private readonly string _mUsername;
            private readonly string _mPassword;
            private readonly AndCondition _mListCondition = new AndCondition(new PropertyCondition(AutomationElement.IsEnabledProperty, true), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            private readonly AndCondition _mEditCondition = new AndCondition(new PropertyCondition(AutomationElement.IsEnabledProperty, true), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            private readonly AndCondition _mButtonConditions = new AndCondition(new PropertyCondition(AutomationElement.IsEnabledProperty, true), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button));
    
            #endregion
    
            #region Constructor
    
            public Windows7LogonDialogHandler(string username, string password)
                : base(username, password)
            {
                _mUsername = username;
                _mPassword = password;
            }
    
            #endregion
    
            #region Public Members
    
            public override bool HandleDialog(Window window)
            {
                if (CanHandleDialog(window))
                {
                    var win = AutomationElement.FromHandle(window.Hwnd);
                    var lists = win.FindAll(TreeScope.Children, _mListCondition);
                    var buttons = win.FindAll(TreeScope.Children, _mButtonConditions);
                    var another = (from AutomationElement list in lists
                                   where list.Current.ClassName == "UserTile"
                                   where list.Current.Name == "Use another account"
                                   select list).First();
                    another.SetFocus();
    
                    foreach (var edit in from AutomationElement list in lists
                                         where list.Current.ClassName == "UserTile"
                                         select list.FindAll(TreeScope.Children, _mEditCondition)
                                             into edits
                                             from AutomationElement edit in edits
                                             select edit)
                    {
                        if (edit.Current.Name.Contains("User name"))
                        {
                            edit.SetFocus();
                            var usernamePattern = edit.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                            if (usernamePattern != null) usernamePattern.SetValue(_mUsername);
                        }
                        if (edit.Current.Name.Contains("Password"))
                        {
                            edit.SetFocus();
                            var passwordPattern = edit.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                            if (passwordPattern != null) passwordPattern.SetValue(_mPassword);
                        }
                    }
                    foreach (var submitPattern in from AutomationElement button in buttons
                                                  where button.Current.AutomationId == "SubmitButton"
                                                  select button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern)
                    {
                        submitPattern.Invoke();
                        break;
                    }
                    return true;
                }
                return false;
            }
    
            public override bool CanHandleDialog(Window window)
            {
                return window.ClassName == "#32770";
            }
    
            #endregion
        }
    }

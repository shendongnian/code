    public static void TabToNextField(this FrameworkElement i
                                    , FrameworkElement nextField
                                    , [CallerMemberName] string memberName = "")
            {
                i.KeyPress(Keys.Tab);
                var isNextFieldFocused = nextField.GetProperty<bool>("IsFocused");
    
                if (!isNextFieldFocused)
                {
                    //Taborder is incorrect. Next field wasn't active!
                    var currentProcedure = memberName;
                    var fromField = i.AutomationId;
                    var toField = nextField.AutomationId;
                }
            }

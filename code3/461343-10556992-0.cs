    private static void addOutlookEncryption(ref Outlook.MailItem mItem) {
            CommandBarButton encryptBtn;
            mItem.Display(false);
            encryptBtn = mItem.GetInspector.CommandBars.FindControl(MsoControlType.msoControlButton, 718, Type.Missing, Type.Missing) as CommandBarButton;
            if (encryptBtn == null) {
                //if it's null, then add the encryption button
                encryptBtn = (CommandBarButton)mItem.GetInspector.CommandBars["Standard"].Controls.Add(Type.Missing, 718, Type.Missing, Type.Missing, true);
            }
            if (encryptBtn.Enabled) {
                if (encryptBtn.State == MsoButtonState.msoButtonUp) {
                    encryptBtn.Execute();
                }
            }
            mItem.Close(Outlook.OlInspectorClose.olDiscard);
        }

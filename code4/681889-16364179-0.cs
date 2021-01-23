        public void RegisterPostbackTrigger(UpdatePanel updatePanel)
        {
            PostBackTrigger buttonTrigger = new PostBackTrigger();
            buttonTrigger.ControlID = TestButton.ClientID;
            updatePanel.Triggers.Add(buttonTrigger);
        }

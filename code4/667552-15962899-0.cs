        public class CommuncationsStatusPresenter
        {
            ...
            
            private void HookEvents()
            {
                m_model.
                    When_Communications_Pulses_Heartbeat += new EventHandler<Tag, EventArgs>(
                    Respond_by_setting_the_state_of_an_Indicator);
            }
            // Eventhandler
            void Respond_by_setting_the_state_of_an_Indicator(Tag sender, EventArgs e)
            {
                ...
            }
        }
    }

        public class CommuncationsStatusPresenter
        {
            ...
            
            private void HookEvents()
            {
                m_model.
                    When_Communications_Pulses_Heartbeat += new EventHandler<Tag, EventArgs>(
                    Set_the_state_of_an_Indicator);
            }
            // Eventhandler
            void Set_the_state_of_an_Indicator(Tag sender, EventArgs e)
            {
                ...
            }
        }
    }

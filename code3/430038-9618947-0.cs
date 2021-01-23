    public class NewLabel : Label
        {
            private readonly object m_AutoValue;
    
            public NewLabel()
            {
                m_AutoValue = base.GetValue(NewLabel.HeightProperty);
    
                NewLabel.HeightProperty.OverrideMetadata(typeof(NewLabel), new PropertyMetadata(
                    new PropertyChangedCallback(
                        (dpo, dpce) =>
                        {
                            if (!dpce.NewValue.Equals(m_AutoValue))
                            {
                                ((NewLabel)dpo).ClearValue(Label.HeightProperty);
                            }
                        })));
            }
        }

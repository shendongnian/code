    void ConversationManager_ConversationAdded(object sender, Microsoft.Lync.Model.Conversation.ConversationManagerEventArgs e)
    {
        e.Conversation.Modalities[ModalityTypes.InstantMessage].ModalityStateChanged += IMModalityStateChanged;
        e.Conversation.Modalities[ModalityTypes.AudioVideo].ModalityStateChanged += AVModalityStateChanged;
    }
    
    void IMModalityStateChanged(object sender, ModalityStateChangedEventArgs e)
    {
        if (e.NewState == ModalityState.Connected)
            MessageBox.Show("IM Modality Connected");
    }
    
    void AVModalityStateChanged(object sender, ModalityStateChangedEventArgs e)
    {
        if (e.NewState == ModalityState.Connected)
            MessageBox.Show("AV Modality Connected");
    }

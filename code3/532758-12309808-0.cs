    var chButtons = new List<IGameUserInterfaceImageButton>();
    chButtons.Add(
        (IGameUserInterfaceImageButton)new GuiSelectCharacterButton(
            // etc ...
        )
    );
    // this is now valid
    buttoncontainer.ButtonList = chButtons

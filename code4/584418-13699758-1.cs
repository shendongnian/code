    private void InitializeDice()
    {
        _Dice = new Dice();
        _Dice.RollingChanged += OnDiceRollingChanged;
        _Dice.Rolled += OnDiceRolled;
    }
    void OnDiceRolled(object sender, EventArgs e)
    {
        buttonRoll.Enabled = true;
    }
    void OnDiceRollingChanged(object sender, EventArgs e)
    {
        // ToDo: Select desired picture from image list depending on _Dice.Result
        labelDiceResult.Text = _Dice.Result.ToString();
    }
    private void OnButtonRollClick(object sender, EventArgs e)
    {
        buttonRoll.Enabled = false;
        _Dice.Roll();
    }

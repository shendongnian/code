    public void InitiateAttack(Character character)
    {
        character.Attack();
    }
----------
    Warrior zizo = new Warrior();
    Wizard hang = new Wizard();
    
    InitiateAttack(zizo);
    InitiateAttack(hang);

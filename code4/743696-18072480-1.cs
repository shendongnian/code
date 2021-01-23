    public CharacterSheet CharSheet(string API, int KEY, int USER)
    {
        CharacterSheet CharSheet = new CharacterSheet();
        EveApi api = new EveApi(KEY, API, USER);
        CharacterSheet csname = api.GetCharacterSheet();
        return csname;
    }

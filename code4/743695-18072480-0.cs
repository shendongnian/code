    public string CharSheet(string API, int KEY, int USER)
    {
        string Charsname = null;
        CharacterSheet CharSheet = new CharacterSheet();
        EveApi api = new EveApi(KEY, API, USER);
        CharacterSheet csname = api.GetCharacterSheet();
        Charsname = csname.Name;
        return Charsname;
    }

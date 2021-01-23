    // keep a list of the languages for later
    static Dictionary<string, List<Thing>> languages = new Dictionary<string, List<Thing>>(){
        {"English", English},
        {"Spanish", Spanish},
        {"German", German}
    };
    // result[3]["English"] = "three"
    public Dictionary<int, Dictionary<string, string>> ListEmAll_better() {
        Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
        foreach(var lang in languages.Keys) {
            foreach(var thing in languages[lang]) {
                if(!result.ContainsKey(thing.ID)) {
                    result[thing.ID] = new Dictionary<string, string>();
                }
                result[thing.ID][lang] = thing.Stuff;
            }
        }
        return result;
    }

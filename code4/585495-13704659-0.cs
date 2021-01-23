    public class PreferenceOption<T>
    {
        public T PreferenceOption {get;set;}
        public string PreferenceOptionName {get;set;}
    }
    PreferenceOption WantsHouse = new PreferenceOption<bool> () { PreferenceOption = true, Weighting = Weighting.Low, PreferenceOptionName ="asd"};
    PreferenceOption WantsHouse2 = new PreferenceOption<string> () { PreferenceOption = "this is a string", Weighting = Weighting.Low, PreferenceOptionName="qwe"};

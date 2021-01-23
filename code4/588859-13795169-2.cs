    SortedList slLanguage = new SortedList(); //Initializes a new SortedList of name slLanguage
    //Add the keys and their values to the list
    slLanguage.Add("Bahasa", "id-ID");
    slLanguage.Add("Chinese Simplified(中文简体)", "zh-CN");
    slLanguage.Add("Chinese Traditional(中文繁體)", "zh-TW");
    slLanguage.Add("Kazakh", "kk-KZ");
    slLanguage.Add("Russian(русский)", "ru-RU");
    slLanguage.Add("Vietnamese(Việt)", "vi-VN");
    slLanguage.Add("English", "en-US");
    //
    object returnedKey = slLanguage.GetKey(slLanguage.IndexOfValue("zh-CN")); //Gets the key from zh-CN as returnedKey of type object

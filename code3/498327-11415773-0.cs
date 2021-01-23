    public bool isCyrillic(string textInput)
    {
    bool rezultat=true;
     string pattern = @"[абвгдѓежзѕијклљмнњопрстќуфхцчџш]";
            char[] textArray = textInput.ToCharArray();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (!Regex.IsMatch(textArray[i].ToString(),pattern))
                {
                    rezultat = false;
                    break;
                }
            }
            return rezultat;
    }

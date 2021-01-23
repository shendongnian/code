    public string DecryptString(string EncryptedString) {
        StringBuilder FinalStr = new StringBuilder();
        int value = 0;
        if (!string.IsNullOrEmpty(EncryptedString)) {
            foreach (char c in EncryptedString) {
                try {
                    value = (int)c;
                    value -= 120;
                    FinalStr.Append(((char)(value)));
                }
                catch (System.Exception e) {
                    return "";
                }
            }
        }
        return Finalstr.ToString;
    }

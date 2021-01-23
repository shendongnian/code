    private string Upper(string s)
    {
        var characters = s.ToCharArray();
        for (int i = 0; i < characters.Length; i++) {
            characters[i] = Upper(characters[i]);
        }
        return new String(characters);
    }
---
    if (<boolean expression>) {
        return true;
    } else {
        return false;
    }

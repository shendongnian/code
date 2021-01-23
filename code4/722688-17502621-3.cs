    string s = "12121.23.2";
    Debug.Assert(s.ContainsDuplicateCharacter('.'));
    Debug.Assert(s.ContainsDuplicateCharacter('1'));
    Debug.Assert(s.ContainsDuplicateCharacter('2'));
    Debug.Assert(!s.ContainsDuplicateCharacter('3'));
    Debug.Assert(!s.ContainsDuplicateCharacter('Z'));

    public static IEnumerable<Key> KeysDown()
    {
        foreach (Key key in Enum.GetValues(typeof(Key)))
        {
            if (Keyboard.IsKeyDown(key))
                yield return key;
        }
    }

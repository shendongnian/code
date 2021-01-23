    Dictionary<int, float> PressedKeysTime = new ...
    void Update(float Elapsed)
    {
          List<int> OldPressedKeys = PressedKeysTime.Keys.ToList();
          foreach (int key in Keyboard.GetState().GetPressedKeys.Cast<int>())
          {
               if (!PressedKeysTime.ContainsKey(key)) 
               {
                    PressedKeysTime[key] = 0;
               } else {
                   OldPressedKeys.Remove(key);
                   PressedKeysTime[key] += Elapsed;
               }
          }
          foreach (int keynotpressed in OldPressedKeys) 
              PressedKeysTime.Remove(keynotpressed);
 
    }

    foreach (var unknown in (dynamic)savedState)
    {
      object dKey = unknown.Key;
      object dValue = unknown.Value;
      switch (dKey.GetType().ToString())
      {
        case "System.String":
          //Save the key
          sKey = (string)dKey;
          switch (dValue.GetType().ToString())
          {
            case "System.String":
              //Save the string value
              sValue = (string)dValue;
              break;
            case "System.Int32":
              //Save the int value
              sValue = ((int)dValue).ToString();
              break;
          }
          break;
      }
      //Show the keypair to the global dictionary
      MessageBox.Show("Key:" + sKey + " Value:" + sValue);
    }

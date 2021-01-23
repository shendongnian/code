      var compared = new Dictionary<string,object>();
      foreach (var kv in first)
      {
          object secondValue;
          if (second.TryGetValue( kv.Key, out secondValue ))
          {
                if (!object.Equals( kv.Value, secondValue ))
                {
                    compared.Add( kv.Key, secondValue );
                }
          }
      }

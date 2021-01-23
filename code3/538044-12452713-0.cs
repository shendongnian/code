      for (int i = 0; i < externals.Count; i++)
      {
          if (!externals[i].StartsWith(mainUrl))
          {
              externals.RemoveAt(i);
          }
      }

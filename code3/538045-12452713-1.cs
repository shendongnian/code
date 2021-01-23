      for (int i = externals.Count - 1; i >= 0; i--)
      {
          if (!externals[i].StartsWith(mainUrl))
          {
              externals.RemoveAt(i);
          }
      }

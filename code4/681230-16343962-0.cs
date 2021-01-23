      foreach (prvEmployeeIncident inc in MyList)
      {
           if (inc.IsCountedAsAPoint)
           {
              inc.IsCountedAsAPoint = false;
              break;
           }
      }

    public IEnumerable<ActiveSemester> GetActiveSemesters()
    {
      int summerSemesterNumber = 1;
      int winterSemesterNumber = 1;
      foreach (ActiveSemester activeSemester in _activeSemesters.OrderBy(c => c.StartDate))
      {
        if (activeSemester.Name == "Summer")
        {                        
          yield return new ActiveSemester(activeSemester)
                           {
                             Name = string.Format("{0} {1}", activeSemester.Name,  
                               ConvertToRomanNumeral(summerSemesterNumber++))
                           };
        }
        else if (activeSemester.Name == "Winter")
        {                        
          yield return new ActiveSemester(activeSemester)
                           {
                             Name = string.Format("{0} {1}", activeSemester.Name,
                               ConvertToRomanNumeral(winterSemesterNumber++))
                           };
        }
        else
        {
          yield return new ActiveSemester(activeSemester);
        }
      }
    }

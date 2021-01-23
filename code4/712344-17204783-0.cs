    public async Task<bool> PopulateListTaskRunAsync(CancellationToken cancellationToken)
    {
      try
      {
        // Clear the records out first, if any
        Records.Clear();
        for (var i = 0; i < 10; i++)
        {
          cancellationToken.ThrowIfCancellationRequested();
          Records.Add(new Model
          {
            Name = NamesList[i],
            Number = i
          });
          Status = "cur: " + i.ToString(CultureInfo.InvariantCulture);
          // Artificial delay so we can see what's going on
          await Task.Delay(200);
        }
        Records[0].Name = "Yes!";
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

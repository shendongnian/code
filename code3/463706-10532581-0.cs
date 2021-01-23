    public string GetMessage(params object[] otherValues)
    {
      return String.Format(Message,
                           FirstValue,
                           GetOrDefault(otherValues, 0),
                           GetOrDefault(otherValues, 1),
                           GetOrDefault(otherValues, 2),
                           GetOrDefault(otherValues, 3),
                           GetOrDefault(otherValues, 4));
    }
    private object GetOrDefault(object[] otherValues, int index)
    {
      if (index < otherValues.Length)
      {
        return otherValues[index];
      }
      return null;
    }

    var peopleWithComments = dao.GetData(123)
      .Where(person => person.Comment.IsPresent());
    ...
    public static class StringExtensions {
      public bool IsPresent(this string self) {
        return !String.IsNullOrWhitespace(self);
      }
    }

    public class MyPage : ...
    {
      private async void OnLoad(...)
      {
        // Set up the "loading" state.
        try
        {
          var books = await BooksManager.GetBooks(...);
          // Transition to the "success" state.
        }
        catch (Exception ex)
        {
          // Transition to the "error" state.
        }
      }
    }

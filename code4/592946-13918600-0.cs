    protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
    {
          if (navigationParameter != null)
          {
               person = (Person)navigationParameter;
          }
    }

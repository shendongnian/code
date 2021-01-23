    public class CodeRepo
    {
      private Dictionary<int, Func<int, int>> snippets = new Dictionary<int, Func<int, int>>();
  
      public void RegisterCodeSnippet(int key, Func<int, int> code)
      {
        if (!snippets.ContainsKey(key))
          snippets.Add(key, code);  
      }
  
      public Func<int, int> GetCodeSnippet(int key)
      {
        if (snippets.ContainsKey(key))
          return snippets[key];
        return null;
      }
  
      public IEnumerable<int> RunAllSnippets(int parameter)
      {
        foreach (var item in snippets)
          yield return item.Value(parameter);
      }
    }

    public object Convert(object value, Type targetType, object parameter, string language)
    {
      // Note that "Result" will wrap any errors in AggregateException, which is annoying.
      return IfFileExist((string)value, "localimage.png").Result;
    }
    public async Task<string> IfFileExist(string value, string filename)
    {
      var folder = ApplicationData.Current.LocalFolder;
      var getFilesAsync = await folder.GetFilesAsync(CommonFileQuery.OrderByName)
          .StartAsTask().ConfigureAwait(false);
      var file = getFilesAsync.FirstOrDefault(x => x.Name == filename);
      if (file != null)
      {
        return "ms-appdata:///local/" + filename;
      }
      return (string)value;
    }

    public static async Task<List<Zajecia>> Deserialize()
    {
      var files = await ApplicationData.Current.LocalFolder.GetFilesAsync(Windows.Storage.Search.CommonFileQuery.OrderByName);
      var file = files.FirstOrDefault(f => f.Name == "Plan_list.xml");
      if (file != null)
      {
        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("Plan_list.xml"))
        {
          XmlSerializer deserializer = new XmlSerializer(typeof(List<Zajecia>));
          return (List<Zajecia>)deserializer.Deserialize(stream);
        }
      }
      else
        return null;
    }

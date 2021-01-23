    public void SaveValues(Values v){
        XmlSerializer serializer = new XmlSerializer(typeof(Values));
        using(TextWriter textWriter = new StreamWriter(@"C:\TheFileYouWantToStore.xml")){
            serializer.Serialize(textWriter, movie);
        }
    }

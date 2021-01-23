    class JsonOuterContent
    { 
       public JsonContent json_content;
    }
    List<JsonOuterContent> list = serializer
          .Deserialize<List<JsonOuterContent>>(myContent);

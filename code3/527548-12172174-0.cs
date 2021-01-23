    [DataContract]
    public class CharacteristicManager
    {
      [DataMember(Order = 1)]
      public Characteristic[] characteristics;
      private Dictionary<String, Characteristic> characteristic_dictionary;
     }

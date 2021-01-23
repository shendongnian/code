     XmlSerializer serializer = new XmlSerializer(typeof(NewReleaseMessage));
     serializer.UnknownAttribute += serializer_UnknownAttribute;
     serializer.UnknownElement += serializer_UnknownElement;
     serializer.UnknownNode += serializer_UnknownNode;
     NewReleaseMessage message = (NewReleaseMessage)serializer.Deserialize(file);
     file.Close();

    case XmlNodeType.Element:
      Console.WriteLine(textReader.Name);
      Console.WriteLine(textReader.Value);
      for (int attInd = 0; attInd < textReader.AttributeCount; attInd++){
          textReader.MoveToAttribute( attInd );
          Console.WriteLine(textReader.Name);
          Console.WriteLine(textReader.Value);
      }
      textReader.MoveToElement(); 

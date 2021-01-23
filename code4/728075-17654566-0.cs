      foreach (var item in elements)
      {
          var codeList = new CodeList();
          codeList.Name = item.Element(dns + "CODELIST_NAME").Value;
          codeList.Description = item.Element(dns + "DESRIPTION").Value;
          codeList.Version = item.Element(dns + "VERSION").Value;
          codeList.EffectiveDate = DateTime.Parse(item.Element(dns + "EFFECTIVE_DATE").Value);
          codeList.ExpirationDate = DateTime.Parse(item.Element(dns + "EXPIRATION_DATE").Value);
          // save code list
      }

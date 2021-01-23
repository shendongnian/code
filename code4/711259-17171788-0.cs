     //your codes 
      foreach (var customAttributeData in attr)
      {
          var result = customAttributeData.NamedArguments;
          foreach (var item in customAttributeData.NamedArguments)
          {
              var name = item.MemberInfo.Name;
              var value = item.TypedValue.Value;
          }
     }
     //your codes

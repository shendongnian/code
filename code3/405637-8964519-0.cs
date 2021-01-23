    foreach (var item in validation) {
       IList<string> memberNames = item.MemberNames.ToArray();
    
       if (memberNames.Count > 0) {
    
          for (int i = 0; i < memberNames.Count; i++)
             controller.ModelState.AddModelError(memberNames[i] ?? "", item.ErrorMessage);
    
       } else {
          controller.ModelState.AddModelError("", item.ErrorMessage);
       }
    }

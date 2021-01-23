    riaContext.SubmitChanges ( (op) =>
      {
        if (!op.HasError)
        {
          var identityAdded = ((Entity) op.ChangeSet.FirstOrDefault()).GetIdentity();
        }
      }

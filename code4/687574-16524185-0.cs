            user.PictureUri = null;
            tableServiceContext.AttachTo(TableNames.User, user);
            tableServiceContext.Update(user);
            tableServiceContext.SaveChanges(SaveChangesOption.ReplaceOnUpdate);
            tableServiceContext.Detach(user);

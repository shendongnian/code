    Contents.Where(x => x.GroupContentPermission.GroupUser.UserId == 169).Select(x => new {
        x.Content,
        x.ListOrder,
        x.ContentTypeId,
        x.ContentId })

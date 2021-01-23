    var profiles = new int[] { 1,2,3,4 };
    
    MessageThreadCountDTO mtcDto = null;
    
    var myResult = 
      _laSession.QueryOver<MessageThreadAccess>()
         .WhereRestrictionOn(x => x.Profile.Id).IsIn(profiles)
         .SelectList(list =>
             list.SelectGroup(x => x.MessageThread).WithAlias(() => mtcDto.Thread).
             SelectCount(x => x.MessageThread).WithAlias(() => mtcDto.Nb)
             )
         .Where(Restrictions.Eq(Projections.Count<MessageThreadAccess>(x => x.MessageThread), profiles.Count()))
         .TransformUsing(Transformers.AliasToBean<MessageThreadCountDTO>())
         .List<MessageThreadCountDTO>().FirstOrDefault();

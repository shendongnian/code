      var srcShipTarget2SrcTarget = Mapper.CreateMap<SourceDataModel.ShipTarget, ShipTarget>()
        .ForMember(newTarget => newTarget.TargetType, c => c.Ignore())
        .AfterMap((srcTarget, newTarget) =>
        {
          if (srcTarget.ProjectTargetType != null)
          {
            newTarget.TargetType = db.TargetTypes.FirstOrDefault(tt => tt.UniqueName == odsT.ProjectTargetType.UniqueName);
            if (newTarget.TargetType == null)
            {
              newTarget.TargetType = Mapper.Map(srcTarget.ShipTarget, newTarget.TargetType);
            }
          }
        });

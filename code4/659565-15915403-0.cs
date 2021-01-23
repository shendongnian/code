    public static Func<MainEntity, OtherEntity, Func<OtherEntity, OtherEntityViewModel>, MainEntityViewModel> 
    				MainMapper = me, oe, oMapper  => new MainEntityViewModel()
    													{
    														Property1 = me.Property1, // direct mapping
    														OtherEntityModel = oMapper.Invoke(oe)
    													};
    		
    		
    public static Func<OtherEntity, OtherEntityViewModel> 
    				OtherMapper = oe => new OtherEntityViewModel()
    										{
    											Name = oe.Name,
    											Description = oe.Description
    										};

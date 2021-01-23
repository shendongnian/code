    Mapper.CreateMap<ItemViewModel, Item>()
        .ForMember(x => x.DestinationArticle, opt => opt.ResolveUsing<SetNullIfSourceHasIdZero>());
    public class SetNullIfSourceHasIdZero : ValueResolver<ItemViewModel, DestinationArticle>
    {
         protected override DestinationArticle ResolveCore(ItemViewModel item)
         {
            // logic here            
         }
    }

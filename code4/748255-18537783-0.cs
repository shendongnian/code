    public class HomePartHandler : ContentHandler {
        public HomePartHandler(IRepository<HomePartRecord> repository, IHomeSearchMLSService homeSearchService) {
            Filters.Add(StorageFilter.For(repository));
            OnLoaded<HomePart>((ctx, part) =>
            {
                part.ConcreteProperty = homeSearchService.GetByMlsNumber(part.MlsId) ?? new PropertyDetail();
            });
            OnIndexing<HomePart>((context, homePart) => context.DocumentIndex
                                                   .Add("home_StreetFullName", homePart.Record.StreetFullName).RemoveTags().Analyze().Store()
                                                   .Add("home_City", homePart.Record.City).RemoveTags().Analyze().Store()
                                                   .Add("home_State", homePart.Record.State).RemoveTags().Analyze().Store()
                                                   .Add("home_Zip", homePart.Record.Zip).RemoveTags().Analyze().Store()
                                                   .Add("home_Subdivision", homePart.Record.Subdivision).RemoveTags().Analyze().Store()
                                                   .Add("home_Beds", homePart.Record.Beds).RemoveTags().Analyze().Store()
                                                   .Add("home_Baths", homePart.Record.Baths).RemoveTags().Analyze().Store()
                                                   .Add("home_SquareFoot", homePart.Record.SquareFoot).RemoveTags().Analyze().Store()
                                                   .Add("home_PropertyType", homePart.Record.PropertyType).RemoveTags().Analyze().Store()
                                                   .Add("home_ListPrice", homePart.Record.ListPrice).RemoveTags().Analyze().Store()
                                                   .Add("home_MlsId", homePart.Record.MlsId).RemoveTags().Analyze().Store()
                                                   .Add("home_Latitude", (double)homePart.Record.Latitude).RemoveTags().Analyze().Store()
                                                   .Add("home_Longitude", (double)homePart.Record.Longitude).RemoveTags().Analyze().Store()
                                                    );
        }
    }

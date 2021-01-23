    public  class PersonEditModelEnricher :
    IModelEnricher<PersonEditModel>
    {
        private readonly ISelectListService _selectListService;
        private readonly IVesselRepository _vesselRepository;
        public PersonEditModelEnricher(ISelectListService selectListService, IVesselRepository vesselRepository)
        {
            _selectListService = selectListService;
        }
        public PersonEditModelEnrich(PersonEditModel model)
        {
            model.Teams = new SelectList(_selectListService.AllTeams(), "Value", "Text")
            return model;
        }
    } 

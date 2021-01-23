    public virtual ActionResult Edit(int id)
    {
        return AutoMappedEnrichedView<PersonEditModel>(_personRepository.Find(id));
    }
    [HttpPost]
    public virtual ActionResult Edit(PersonEditModel person)
    {
         if (ModelState.IsValid){
                //This is simplified (probably don't use Automapper to go VM-->Entity)
                var insertPerson = Mapper.Map<PersonEditModel , Person>(person);
                _personRepository.InsertOrUpdate(insertPerson);
                _requirementRepository.Save();
                return RedirectToAction(Actions.Index());
          }
         return EnrichedView(person);
     }

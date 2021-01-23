    filteredPeople = unitOfWork.PeopleRepository.Get()
                    .Where(c => (IdSearchable
                            && c.personID != null
                            && c.personID.ToString().Contains(param.sSearch.ToLower()))
                        || (surnameSearchable 
                            && c.Surname != null
                            && c.Surname.ToLower().Contains(param.sSearch.ToLower()))
                        || (firstNameSearchable 
                            && c.FirstName != null
                            && c.FirstName.ToLower().Contains(param.sSearch.ToLower()))
                        || (genderSearchable 
                            && c.Gender != null
                            && c.Gender.ToLower().Contains(param.sSearch.ToLower())));

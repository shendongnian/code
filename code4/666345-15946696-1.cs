     public ActionResult AssignPractice(FormCollection form)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var doctor = js.Deserialize<Doctor>(form[0]);
            var doctorViewModel = Map.This(_doctorService.GetDoctor(doctor.Id)).To<DoctorViewModel>();
           
            AddSelectLists(doctorViewModel);
            var practice = _practiceService.GetPractice(doctor.Practice.Id);
            var practiceViewModel = Map.This(practice).To<PracticeViewModel>();
            doctorViewModel.Practice = new PracticeSelectListViewModel() { Item = practice, SelectList = _practices };
            doctorViewModel.FirstName = doctor.FirstName;
            doctorViewModel.LastName = doctor.LastName;
            doctorViewModel.PhoneNumber = doctor.PhoneNumber;
            doctorViewModel.PhoneNumber2 = doctor.PhoneNumber2;
            doctorViewModel.PhoneNumberActive = doctor.PhoneNumberActive;
            doctorViewModel.PhoneNumber2Active = doctor.PhoneNumberActive;
            doctorViewModel.Email = doctor.Email;
            doctorViewModel.OpeningHours = practiceViewModel.OpeningHours;
            doctorViewModel.AppointmentHours = practiceViewModel.AppointmentHours;
            doctorViewModel.AddressViewModel = practiceViewModel.AddressViewModel;
            doctorViewModel.Website = practiceViewModel.Website;
            doctorViewModel.Labo = practiceViewModel.Labo;
            doctorViewModel.KeyChain = practiceViewModel.KeyChain;
            return PartialView("Edit",  doctorViewModel);
        }

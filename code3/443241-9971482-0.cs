    [HttpPost]
    public ActionResult RequestAppointment(AppointmentRequest appointmentRequest)
    {
        if(ModelState.IsValid)
        {
            // Process...
            return RedirectToAction("Confirmation");
        }
    
        appointmentRequest.Stylists = _repository.Stylists;
        return View(appointmentRequest);
    }
